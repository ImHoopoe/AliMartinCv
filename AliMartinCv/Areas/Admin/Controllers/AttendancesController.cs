using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AttendancesController : Controller
    {
        private readonly IAttendance _attendanceServices;
        private readonly IStudent _studentServices;
        public AttendancesController(IAttendance attendanceServices, IStudent studentServices)
        {
            _attendanceServices = attendanceServices;
            _studentServices = studentServices;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var attendance = new CreateAttendanceViewModel()
            {
                Students = await _studentServices.GetAllStudents(id),
            };
            return View(attendance);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateAttendanceViewModel attendance)
        {
            if (!ModelState.IsValid)
            {
                return View(attendance);
            }

            await _attendanceServices.CreateAttendance(attendance);
            return Redirect("/admin/schools/");
        }

        public async Task<IActionResult> ShowAttendances(int id)
        {
            _attendanceServices.ReCheckAll();
            var attendances = await _attendanceServices.ShowClassAttendance(id);

            return View(attendances);
        }
    }
}
