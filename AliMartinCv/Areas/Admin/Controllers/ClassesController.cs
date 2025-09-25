using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClassesController : Controller
    {
        private readonly IClass _classServieces;
        private readonly IStudent _studentServieces;

        public ClassesController(IClass classServieces, IStudent studentServieces)
        {
            _classServieces = classServieces;
            _studentServieces = studentServieces;
        }

        public async Task<IActionResult> Index(int id)
        {
            var selectedClass = await _classServieces.GetClassById(id);
            if (selectedClass == null)
            {
                return NotFound("Not Found Found !");
            }

            ShowClassStudentsViewModel students = new ShowClassStudentsViewModel()
            {
                Students = selectedClass.Students.Where(s => s.ClassId == id),
                ClassName = selectedClass.ClassName,
                SchoolId = selectedClass.SchoolId,
                ClassId = selectedClass.ClassId
            };
            return View(students);
        }


        [HttpGet]
        public IActionResult CreateClass(int id)
        {
            ViewData["SchoolId"] = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass(CreateClassViewModel createClass)
        {
            if (!ModelState.IsValid)
            {
                return View(createClass);
            }

            await _classServieces.CreateClass(createClass);
            return Redirect($"/admin/Schools/Index/");
        }

        public async Task<IActionResult> Attendance(int id)
        {
            var selectedClass = await _classServieces.GetClassById(id);
            if (selectedClass == null)
            {
                return NotFound("Not Found Found !");
            }

            ShowClassStudentsViewModel students = new ShowClassStudentsViewModel()
            {
                Students = selectedClass.Students.Where(s => s.ClassId == id),
                ClassName = selectedClass.ClassName,
                SchoolId = selectedClass.SchoolId,
                ClassId = selectedClass.ClassId
            };
            return View(students);
        }


    }
}
