using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.DTos;
using AliMartinCv.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AliMartinCv.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SchoolsController : Controller
    {
        private readonly ISchool _schoolServices;
        private readonly IClass _ClassServices;
        public SchoolsController(ISchool schoolServices, IClass classServices)
        {
            _schoolServices = schoolServices;
            _ClassServices = classServices;
        }


        public async Task<IActionResult> Index()
        {
            IndexSchoolViewModel index = new IndexSchoolViewModel()
            {
                Classes = await _ClassServices.GetAllClasses(),
                Schools = await _schoolServices.GetSchools(),
                
            };
            return View(index);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSchool()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchool(AddSchoolViewModel newSchool)
        {
            if (!ModelState.IsValid)
            {
                return View(newSchool);
            }

            await _schoolServices.CreateSchool(newSchool);
            return Redirect("/Admin/Schools/Index/");
        }

        [HttpGet]
        public async Task<IActionResult> EditSchool(int id)
        {
            var school = await _schoolServices.GetSchoolByIdentifier(id);
            if (school == null)
            {
                return NotFound();
            }

            var editModel = new EditSchoolViewModel
            {
                SchoolId = school.SchoolId,
                SchoolName = school.SchoolName
            };

            return View(editModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditSchool(EditSchoolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _schoolServices.EditSchool(model);
            return Redirect("/Admin/Schools/Index/");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _schoolServices.GetSchoolByIdentifier(id);
            if (school == null)
            {
                return NotFound();
            }

            await _schoolServices.DeleteSchool(id);
            return Json(new { success = true });
        }

    }
}
