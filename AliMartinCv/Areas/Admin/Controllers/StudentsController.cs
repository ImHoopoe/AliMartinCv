using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.Core.Sevices.Services;
using AliMartinCv.DataLayer.DTos;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentsController : Controller
    {
        private readonly IClass _classServieces;
        private readonly IStudent _studentServieces;

        public StudentsController(IClass classServieces, IStudent studentServieces)
        {
            _classServieces = classServieces;
            _studentServieces = studentServieces;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateStudent(int id)
        {
            var currentClass = await _classServieces.GetClassById(id);
            if (currentClass == null)
                return NotFound();
            ViewData["ClassId"] = currentClass.ClassId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentViewModel newStudent)
        {
            if (!ModelState.IsValid)
            {
                return View(newStudent);
            }

            await _studentServieces.CreateStudent(newStudent);
            return Redirect($"/admin/classes/Index/{newStudent.ClassId}");
        }
    }
}
