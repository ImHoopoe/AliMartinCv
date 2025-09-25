using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BlogGroupsController : Controller
    {
        private readonly IBlogGroup _BlogServices;
        public BlogGroupsController(IBlogGroup BlogServices)
        {
            _BlogServices = BlogServices;
        }


        public IActionResult Index()
        {

            return View(_BlogServices.GetBlogGroups());
        } 
        
        public IActionResult CreateBlogGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlogGroup(BlogGroup blogGroups)
        {
            _BlogServices.CreateNewBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }

        public IActionResult EditBlogGroup(Guid id)
        {
            ViewBag.Id = id;
            
            return View(_BlogServices.GetBlogGroupById(id));
        }

        [HttpPost]
        public IActionResult EditBlogGroup(BlogGroup blogGroups)
        {
            _BlogServices.UpdateBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }

        public IActionResult DeleteBlogGroup(Guid id)
        {
            var blogGroup = _BlogServices.GetBlogGroupById(id);
            ViewBag.id = id;
            ViewBag.subId = blogGroup.BlogGroupParentId;
            ViewBag.GroupTitle = blogGroup.BlogGroupTitle;

            return View(blogGroup);
        }

        [HttpPost]
        public IActionResult DeleteBlogGroup(BlogGroup blogGroups)
        {
            _BlogServices.DeleteBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }




        public IActionResult AddSubGroup(Guid id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost]
        public IActionResult AddSubGroup(BlogGroup blogGroups)
        {
            _BlogServices.CreateNewBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }

        public IActionResult EditSubGroup(Guid id)
        {
            var subGroup = _BlogServices.GetBlogGroupById(id);
            
            ViewBag.id = id;
            ViewBag.subId = subGroup.BlogGroupParentId;
            return View(subGroup);
        }

        [HttpPost]
        public IActionResult EditSubGroup(BlogGroup blogGroups)
        {
           
            _BlogServices.UpdateBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }

        public IActionResult DeleteBlogSubGroup(Guid id)
        {
            var blogGroup = _BlogServices.GetBlogGroupById(id);
            ViewBag.id = id;
            ViewBag.subId = blogGroup.BlogGroupParentId;
            ViewBag.GroupTitle = blogGroup.BlogGroupTitle;

            return View(blogGroup);
        }

        [HttpPost]
        public IActionResult DeleteBlogSubGroup(BlogGroup blogGroups)
        {
            _BlogServices.DeleteBlogGroup(blogGroups);
            return Redirect("/Admin/BlogGroups/");
        }

    }
}
