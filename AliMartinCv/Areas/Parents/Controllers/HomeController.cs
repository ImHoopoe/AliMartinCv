using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AliMartinCv.Areas.Parents.Controllers
{
    [Area("Parents")]
    [Authorize(Roles = "Parent,Admin")]
    public class HomeController : Controller
    {
        private readonly IParent _parentServices;
        private readonly IStudent _studentServices;
        private readonly IAttendance _attendanceServices;
        public HomeController(IParent parentServices, IStudent studentServices, IAttendance attendanceServices)
        {
            _parentServices = parentServices;
            _studentServices = studentServices;
            _attendanceServices = attendanceServices;
        }

        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value; 
            ViewData["StudentsCount"] = await _studentServices.GetStudentsCounts(null,null);
            ViewData["AttendancesCount"] = await _attendanceServices.GetStudentAttendancesCounts(Guid.Parse("9607ab46-51db-4ad1-806c-850b20d093d0"));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> StudentInformation()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");
            
            
            var claimValue = User.FindFirstValue(ClaimTypes.NameIdentifier);

            
            if (!Guid.TryParse(claimValue, out Guid studentId))
            {
                // اگه مقدار معتبر نبود، برگرد به لاگین
                return RedirectToAction("Login", "Account");
            }
            if (await _parentServices.IsProfileCompleted(studentId))
            {
                return NotFound("قبلا پروفایل این دانش آموز تکمیل شده است");
            }
            ViewBag.StudentId = studentId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> StudentInformation(StudentInformationViewModel student)
        {
           await _parentServices.CompleteProfile(student);

            return View();
        }
    }
}
