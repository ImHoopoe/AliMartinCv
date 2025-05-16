using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
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

            return View(await _blogServices.GetAllBlogs());
        }

        public IActionResult CreateBlog()
        {
            var mainGroups = _blogGroupServices.GetAllMainGroups();
            ViewBag.Maingroups = mainGroups;

            var subGroups = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "_Choose_",
                    Value = "00000000-0000-0000-0000-000000000000"
                }
            };

            subGroups.AddRange(_blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value)));

            _blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value));
            ViewBag.SubGroups = subGroups;
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(Blog blog, IFormFile? SelectPicture)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _blogServices.CreateNewBlog(blog, SelectPicture);
            return Redirect("/Admin/Blogs/Index/");
        }


        public async Task<IActionResult> EditBlog(Guid id)
        {
            var mainGroups = _blogGroupServices.GetAllMainGroups();
            ViewBag.Maingroups = mainGroups;

            var subGroups = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "_Choose_",
                    Value = "00000000-0000-0000-0000-000000000000"
                }
            };
            subGroups.AddRange(_blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value)));
            _blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value));
            ViewBag.SubGroups = subGroups;


            return View(await _blogServices.GetBlogById(id));
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog, IFormFile? SelectPicture)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _blogServices.UpdateBlog(blog, SelectPicture);

            return View();
        }

        public async Task<IActionResult> DeleteBlog(Guid id)
        {
            var mainGroups = _blogGroupServices.GetAllMainGroups();
            ViewBag.Maingroups = mainGroups;

            var subGroups = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "_Choose_",
                    Value = "00000000-0000-0000-0000-000000000000"
                }
            };
            subGroups.AddRange(_blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value)));
            _blogGroupServices.GetSubGroups(Guid.Parse(mainGroups.First().Value));
            ViewBag.SubGroups = subGroups;
            return View(await _blogServices.GetBlogById(id));
        }

        [HttpPost]
        public IActionResult DeleteBlog(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _blogServices.DeleteBlog(blog);
            return Redirect("/Admin/Blogs/Index/");
        }


        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Blog/BlogImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/Blog/BlogImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }


        public IActionResult GetSubGroups(Guid id)
        {

            var subGroups = _blogGroupServices.GetAllSubGroups(id);
            subGroups.Insert(0, new SelectListItem()
            {
                Text = "_Choose_",
                Value = "00000000-0000-0000-0000-000000000000"
            });

            return Json(new SelectList(subGroups, "Value", "Text"));

        }


    }
}
