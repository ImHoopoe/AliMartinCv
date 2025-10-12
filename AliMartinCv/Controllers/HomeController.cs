using AliMartinCv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.context;
using Microsoft.EntityFrameworkCore;

namespace AliMartinCv.Controllers
{
    [ProfileStatusChecker("/parents/Home/StudentInformation")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBlog _blogServices;
        private readonly AliMartinCvContext _context;

        public HomeController(ILogger<HomeController> logger, IBlog blogServices, AliMartinCvContext context)
        {
            _logger = logger;
            _blogServices = blogServices;
            _context = context;
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

        public async Task<IActionResult> IsActivated()
        {
            var s = await _context.Students.ToListAsync();
            foreach (var st in s)
            {
                var parentId = await _context.Parents.SingleOrDefaultAsync(p => p.StudentId == st.StudentId);
                st.ParentId = parentId.ParentId;
                _context.Students.Update(st);
                
            }
            await _context.SaveChangesAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
