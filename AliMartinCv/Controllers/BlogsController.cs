using AliMartinCv.Core.DTOS.BlogViewModels;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Sevices.Services;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlog _blogService;

        public BlogsController(IBlog blogService)
        {
            _blogService = blogService;
        }
        public async Task<IActionResult> Index(string searchQuery, int page = 1)
        {
            // تعداد بلاگ‌ها در هر صفحه
            int pageSize = 6;

            // فرضاً یه متد برای گرفتن بلاگ‌ها داریم
            var allBlogs = await _blogService.GetAllBlogs();

            // جست‌وجو
            if (!string.IsNullOrEmpty(searchQuery))
            {
                searchQuery = searchQuery.ToLower();
                allBlogs = allBlogs
                    .Where(b => b.BlogTitle.ToLower().Contains(searchQuery) ||
                                b.BlogShortDescription.ToLower().Contains(searchQuery))
                    .ToList();
            }

            // صفحه‌بندی
            int totalBlogs = allBlogs.Count();
            int totalPages = (int)Math.Ceiling((double)totalBlogs / pageSize);
            var blogs = allBlogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var viewModel = new BlogListViewModel
            {
                Blogs = blogs,
                SearchQuery = searchQuery,
                CurrentPage = page,
                TotalPages = totalPages,
                PageSize = pageSize
            };

            return View(viewModel);
        }
    }
}
