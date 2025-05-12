using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Tools;
using AliMartinCv.DataLayer.context;
using AliMartinCv.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using AliMartinCv.Core.DTOS.BlogViewModels;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using AliMartinCv.Core.Convertors;
using AliMartinCv.Core.Security;

namespace AliMartinCv.Core.Sevices.Services
{
    public class BlogServices : IBlog
    {
        private readonly AliMartinCvContext _context;

        public BlogServices(AliMartinCvContext context)
        {
            _context = context;
        }

        public int VisitsCount()
        {
            int visits = 0;
            int[] BlogVisits = GetAllBlogs().Select(b => b.Visit).ToArray();
            foreach (var visit in BlogVisits)
            {
                visits += visit;
            }
            return visits;
        }

        public Guid CreateNewBlog(Blog blog, IFormFile? File)
        {
            blog.BlogThumbnail = "Default.png";
            if (File != null && File.IsImage())
            {

                blog.BlogThumbnail = Guid.NewGuid() + Path.GetExtension(File.FileName);
                string BannerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/ThumnailsImage/", blog.BlogThumbnail);
                using (FileStream fs = new FileStream(BannerPath, FileMode.Create))
                {
                    File.CopyTo(fs);
                }
                string ThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Thumbs/", blog.BlogThumbnail);

                ImageConvertor.ResizeAndSaveImage(BannerPath, ThumbPath, 150, 150);


            }



            if (blog.BlogSubGroupId == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                blog.BlogSubGroupId = null;
            }
            blog.BlogId = Tools.Tools.UniqNameMaker();
            blog.Visit = 0;
            blog.BlogPublishDate = DateTime.Now;
            _context.Add(blog);
            _context.SaveChanges();
            return blog.BlogId;
        }

        public void DeleteBlog(Blog blog)
        {
            blog.BlogIsDeleted = true;
            _context.Update(blog);
            _context.SaveChanges();
        }

        public IList<ShowBlogsViewModel> GetAllBlogs()
        {
            return _context.Blogs.Select(b => new ShowBlogsViewModel()
            {

                BlogShortDescription = b.BlogShortDescription,
                BlogIsDeleted = b.BlogIsDeleted,
                BlogTitle = b.BlogTitle,
                BlogThumbnail = b.BlogThumbnail,
                Visit = b.Visit.Value,
                BlogPublishDate = b.BlogPublishDate,
                BlogId = b.BlogId,
                BlogGroupTitle = _context.BlogGroups
                    .Where(g => g.BlogGroupId == b.BlogGroupId)
                    .Select(g => g.BlogGroupTitle)
                    .SingleOrDefault(),
                BlogSubGroupTitle = _context.BlogGroups
                    .Where(g => g.BlogGroupId == b.BlogSubGroupId)
                    .Select(g => g.BlogGroupTitle)
                    .SingleOrDefault(),
            }).ToList();
        }

        public Blog GetBlogById(Guid id)
        {
            return _context.Blogs.Find(id);
        }

        public void UpdateBlog(Blog blog,IFormFile File)
        {
            if (File != null && File.IsImage())
            {
                string BannerPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/ThumnailsImage/", blog.BlogThumbnail);
                string DeleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Thumbs/", blog.BlogThumbnail);

                if (System.IO.File.Exists(BannerPath))
                {
                    System.IO.File.Delete(BannerPath);
                    
                }
                if (System.IO.File.Exists(DeleteThumbPath))
                {
                    System.IO.File.Delete(DeleteThumbPath);
                    
                }

                blog.BlogThumbnail = Guid.NewGuid() + Path.GetExtension(File.FileName);
                using (FileStream fs = new FileStream(BannerPath, FileMode.Create))
                {
                    File.CopyTo(fs);
                }
                string ThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/Thumbs/", blog.BlogThumbnail);

                ImageConvertor.ResizeAndSaveImage(BannerPath, ThumbPath, 150, 150);


            }
            _context.Update(blog);
            _context.SaveChanges();
        }

        public int BlogsCount()
        {
            return _context.Blogs.Count();
        }

        public List<ShowLastBlogsViewModel> GetLastBlogs()
        {
           return _context.Blogs.OrderBy(b => b.BlogPublishDate).Take(5).Select(b =>
                new ShowLastBlogsViewModel()
                {
                    BlogId = b.BlogId,
                    BlogTitle = b.BlogTitle,
                    BlogImage = b.BlogThumbnail,
                    BlogShortDesciption = b.BlogShortDescription,
                    Visits = b.Visit.Value
                }).ToList();
        }
    }
}
