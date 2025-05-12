using AliMartinCv.Core.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IBlog _blogServices;
        private readonly IBlogGroup _blogGroupServices;

        public HomeController(IBlog blogServices, IBlogGroup blogGroupServices)
        {
            _blogServices = blogServices;
            _blogGroupServices = blogGroupServices;
        }

        public IActionResult Index()
        {
            ViewBag.BlogCount = _blogServices.BlogsCount();
            ViewBag.BlogGroupsCount = _blogGroupServices.GroupsCount();
            ViewBag.BlogSubGroupsCount = _blogGroupServices.SubGroupCounts();
            ViewBag.VisitCount = _blogServices.VisitsCount();
            ViewBag.LastBlogs = _blogServices.GetLastBlogs();
            return View();
        }
    }
}
