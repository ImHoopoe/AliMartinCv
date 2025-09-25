using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Tools;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using AliMartinCv.Core.DTOS.BlogViewModels;
using AliMartinCv.Core.Convertors;
using AliMartinCv.Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AliMartinCv.Core.Sevices.Services
{
    public class BlogServices : IBlog
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BlogServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // هر دفعه کانتکست را از همان scope جاری می‌گیریم:
        private AliMartinCvContext Context =>
            _httpContextAccessor.HttpContext!
                .RequestServices
                .GetRequiredService<AliMartinCvContext>();

        public async Task<List<ShowBlogsViewModel>> GetAllBlogs()
        {
            return await Context.Blogs
                .Select(b => new ShowBlogsViewModel
                {
                    BlogShortDescription = b.BlogShortDescription,
                    BlogIsDeleted = b.BlogIsDeleted,
                    BlogTitle = b.BlogTitle,
                    BlogThumbnail = b.BlogThumbnail,
                    Visit = b.Visit ?? 0,
                    BlogPublishDate = b.BlogPublishDate,
                    BlogId = b.BlogId,
                    BlogGroupTitle = Context.BlogGroups
                                             .Where(g => g.BlogGroupId == b.BlogGroupId)
                                             .Select(g => g.BlogGroupTitle)
                                             .SingleOrDefault(),
                    BlogSubGroupTitle = Context.BlogGroups
                                             .Where(g => g.BlogGroupId == b.BlogSubGroupId)
                                             .Select(g => g.BlogGroupTitle)
                                             .SingleOrDefault(),
                })
                .ToListAsync();
        }

        public async Task<Blog> GetBlogById(Guid id)
            => await Context.Blogs.FindAsync(id);

        public async Task<Blog> GetBlogByTitle(string id)
        {
            var blogs = await Context.Blogs
                .Where(b => b.BlogTitle == id)
                .ToListAsync();

            if (blogs.Count == 0)
                throw new InvalidOperationException($"No blog found with title '{id}'.");

            if (blogs.Count > 1)
                throw new InvalidOperationException($"Multiple blogs found with title '{id}'.");

            return blogs.Single(); // safe now
        }


        public async Task<bool> CreateNewBlog(Blog blog, IFormFile? file)
        {
            blog.BlogThumbnail = "Default.png";

            if (file != null)
            {
                await using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                if (memoryStream.IsImage())
                {
                    blog.BlogThumbnail = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

                    string uploadsRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Blog");
                    string bannerPath = Path.Combine(uploadsRoot, "ThumnailsImage", blog.BlogThumbnail);
                    string thumbPath = Path.Combine(uploadsRoot, "Thumbs", blog.BlogThumbnail);

                    Directory.CreateDirectory(Path.GetDirectoryName(bannerPath)!);
                    Directory.CreateDirectory(Path.GetDirectoryName(thumbPath)!);

                    await using (var fs = new FileStream(bannerPath, FileMode.Create))
                    {
                        memoryStream.Position = 0;
                        await memoryStream.CopyToAsync(fs);
                    }

                    ImageConvertor.ResizeAndSaveImage(bannerPath, thumbPath, 150, 150);
                }
            }

            if (blog.BlogSubGroupId == Guid.Empty)
                blog.BlogSubGroupId = null;

            blog.BlogId = Tools.Tools.UniqNameMaker();
            blog.Visit = 0;
            blog.BlogPublishDate = DateTime.Now;

            await Context.Blogs.AddAsync(blog);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBlog(Blog blog, IFormFile? file)
        {
            if (file != null)
            {
                DeleteExistingImages(blog.BlogThumbnail);

                var newName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);
                blog.BlogThumbnail = newName;

                string uploadsRoot = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Blog");
                string bannerPath = Path.Combine(uploadsRoot, "ThumnailsImage", newName);
                string thumbPath = Path.Combine(uploadsRoot, "Thumbs", newName);

                Directory.CreateDirectory(Path.GetDirectoryName(bannerPath)!);
                Directory.CreateDirectory(Path.GetDirectoryName(thumbPath)!);

                await using (var fs = new FileStream(bannerPath, FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }

                ImageConvertor.ResizeAndSaveImage(bannerPath, thumbPath, 150, 150);
            }

            Context.Update(blog);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBlog(Blog blog)
        {
            

            Context.Update(blog);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBlog(Blog blog)
        {
            blog.BlogIsDeleted = true;
            Context.Update(blog);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ShowBlogsViewModel>> GetLastBlogs(int take = 3)
        {
            return await Context.Blogs
                .OrderByDescending(b => b.BlogPublishDate)
                .Take(take)
                .Select(b => new ShowBlogsViewModel
                {
                    BlogId = b.BlogId,
                    BlogTitle = b.BlogTitle,
                    BlogThumbnail = b.BlogThumbnail,
                    BlogShortDescription = b.BlogShortDescription,
                    Visit = b.Visit ?? 0
                })
                .ToListAsync();
        }

        public async Task<int> VisitsCount()
            => await Context.Blogs.SumAsync(b => b.Visit ?? 0);

        public async Task<int> BlogsCount()
            => await Context.Blogs.CountAsync();

        private void DeleteExistingImages(string fileName)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Blog");
            var oldBanner = Path.Combine(basePath, "ThumnailsImage", fileName);
            var oldThumb = Path.Combine(basePath, "Thumbs", fileName);

            if (File.Exists(oldBanner)) File.Delete(oldBanner);
            if (File.Exists(oldThumb)) File.Delete(oldThumb);
        }
    }
}
