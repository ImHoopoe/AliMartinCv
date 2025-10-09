using AliMartinCv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AliMartinCv.Core.Sevices.Interfaces;

namespace AliMartinCv.Controllers
{
    [ProfileStatusChecker("/parents/Home/StudentInformation")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlog _blogServices;
        public HomeController(ILogger<HomeController> logger, IBlog blogServices)
        {
            _logger = logger;
            _blogServices = blogServices;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogServices.GetLastBlogs();
            return View(blogs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
