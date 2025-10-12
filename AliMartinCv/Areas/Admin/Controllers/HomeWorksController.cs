using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class HomeWorksController : Controller
    {
        private readonly IClass _classServices;
        private readonly IHomeWork _homeWorkServices;
        public HomeWorksController(IClass classServices, IHomeWork homeWorkServices)
        {
            _classServices = classServices;
            _homeWorkServices = homeWorkServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddHomeWork()
        {
            ViewData["Classes"] = await _classServices.GetAllClasses();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomeWork(AddHomeWorkViewModel addHomeWork)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/Admin/HomeWorks/AddHomeWork");
            }

           await _homeWorkServices.AddHomeWork(addHomeWork);
            return View();
        }
    }
}
