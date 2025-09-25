using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogsController : Controller
    {
        private readonly IBlog _blogServices;
        private readonly IBlogGroup _blogGroupServices;

        public BlogsController(IBlog blogServices, IBlogGroup blogGroupServices)
        {
            _blogServices = blogServices;
            _blogGroupServices = blogGroupServices;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogServices.GetAllBlogs();
            return View(blogs);
        }

        public async Task<IActionResult> CreateBlog()
        {
            var mainGroups = await _blogGroupServices.GetAllMainGroups();
            ViewBag.Maingroups = mainGroups;

            var firstGroupId = mainGroups.FirstOrDefault()?.Value;
            var subGroups = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "_Choose_",
                    Value = Guid.Empty.ToString()
                }
            };

            if (Guid.TryParse(firstGroupId, out var parsedId))
            {
                subGroups.AddRange(await _blogGroupServices.GetSubGroups(parsedId));
            }

            ViewBag.SubGroups = subGroups;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(Blog blog, IFormFile? SelectPicture)
        {
            if (!ModelState.IsValid)
            {
                var mainGroups = await _blogGroupServices.GetAllMainGroups();
                ViewBag.Maingroups = mainGroups;

                ViewBag.SubGroups = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = "_Choose_",
                        Value = Guid.Empty.ToString()
                    }
                };

                return View(blog);
            }

            await _blogServices.CreateNewBlog(blog, SelectPicture);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditBlog(Guid id)
        {
            var blog = await _blogServices.GetBlogById(id);
            if (blog == null) return NotFound();

            var mainGroups = await _blogGroupServices.GetAllMainGroups();
            ViewBag.Maingroups = mainGroups;

            var subGroups = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "_Choose_",
                    Value = Guid.Empty.ToString()
                }
            };

            var firstGroupId = mainGroups.FirstOrDefault()?.Value;
            if (Guid.TryParse(firstGroupId, out var parsedId))
            {
                subGroups.AddRange(await _blogGroupServices.GetSubGroups(parsedId));
            }

            ViewBag.SubGroups = subGroups;

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> EditBlog(Blog blog, IFormFile? SelectPicture)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            await _blogServices.UpdateBlog(blog, SelectPicture);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var blog = await _blogServices.GetBlogById(id);
            if (blog == null) return NotFound();

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }

            await _blogServices.DeleteBlog(blog);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("file-upload")]
        public async Task<IActionResult> UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload?.Length <= 0)
                return BadRequest("Invalid file.");

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(upload.FileName).ToLower()}";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Blog/BlogImages", fileName);

            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await upload.CopyToAsync(stream);
            }

            var url = $"/Blog/BlogImages/{fileName}";
            return Json(new { uploaded = true, url });
        }

        public async Task<IActionResult> GetSubGroups(Guid id)
        {
            var subGroups =  _blogGroupServices.GetAllSubGroups(id);
            subGroups.Insert(0, new SelectListItem
            {
                Text = "_Choose_",
                Value = Guid.Empty.ToString()
            });

            return Json(new SelectList(subGroups, "Value", "Text"));
        }
    }
}
