using AliMartinCv.Core.Sevices.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly IBlog _blogServices;
        private readonly IBlogGroup _blogGroupServices;

        public HomeController(IBlog blogServices, IBlogGroup blogGroupServices)
        {
            _blogServices = blogServices;
            _blogGroupServices = blogGroupServices;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BlogCount = await _blogServices.BlogsCount();
            ViewBag.BlogGroupsCount = await _blogGroupServices.GroupsCount();
            ViewBag.BlogSubGroupsCount = await _blogGroupServices.SubGroupCounts();
            ViewBag.VisitCount = await _blogServices.VisitsCount();
            ViewBag.LastBlogs = await _blogServices.GetLastBlogs();
            return View();
        }
    }
}
