using AliMartinCv.Core.Sevices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Student.Controllers
{
    [Area("Student")]
    public class HomeController : Controller
    {
        private readonly IAttendance _attendanceServices;
        public HomeController(IAttendance attendanceServices)
        {
            _attendanceServices = attendanceServices;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Attendances(Guid id)
        {
            //Todo : Add Check Id
            if (id==null)
            {
                return BadRequest(
                    "این ارور برای شمایی که id را دستکاری کردین در نظر گرفته شده است، لطفا مجددا شیطونی نکنید...ممنون");
            }

            var attendances =await _attendanceServices.ShowStudentAttendance(id);
            return View(attendances);
        }

    }
}
