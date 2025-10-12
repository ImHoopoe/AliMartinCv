using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using AliMartinCv.Core.Sevices.Interfaces;
using AliMartinCv.DataLayer.Entities;

namespace AliMartinCv.Controllers
{
    public class AccountController : Controller
    {
        private readonly IStudent _studentServices;
        private readonly IParent _parentServices;
        private readonly string _adminUserName;
        private readonly string _adminPassword;

        public AccountController(IStudent studentServices, IParent parentServices, IConfiguration configuration)
        {
            _studentServices = studentServices;
            _parentServices = parentServices;
            _adminUserName = configuration["AdminCredentials:UserName"];
            _adminPassword = configuration["AdminCredentials:Password"];
        }

        [HttpGet("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/Login")]
        public async Task<IActionResult> Login(string userName, string password, string returnUrl = null)
        {
            
            returnUrl ??= "/admin/blogs/";

            if (await AuthenticateUser(userName, password, "Admin", _adminUserName, _adminPassword,Guid.NewGuid(),null))
            {
                return Redirect(returnUrl); 
            }

            if (await _studentServices.IsStudentExists(userName))
            {
                var student = await _studentServices.GetStudentByUserName(userName);
                if (student.Password == password.HashPassword() && student.IsActivated.Value)
                {
                    returnUrl = "/students/home/index";
                    await SignInUser(userName, "Student",student.StudentId, student.ParentId);
                    return Redirect(returnUrl); 
                }
                else
                {
                    ViewBag.Error = "اکانت شما توسط والدین فعال نشده است !.";
                    return View(userName);
                }
            }

            if (await _parentServices.IsExistsParent(userName))
            {
                var parent = await _parentServices.GetParentByUserName(userName);
                var student = await _studentServices.GetStudentIdByParentId(parent.ParentId);
                if (parent.Password == password.HashPassword())
                {
                    returnUrl = "/parents/home/index";
                    await SignInUser(userName, "Parent",parent.ParentId,parent.StudentId);
                    return Redirect(returnUrl); 
                }
            }

            ViewBag.Error = "نام کاربری یا رمز عبور اشتباه است.";
            return View();
        }


        private async Task<bool> AuthenticateUser(string userName, string password, string role, string storedUserName, string storedPassword,Guid userId,Guid? studentId)
        {
            if (userName == storedUserName && password.HashPassword() == storedPassword.HashPassword())
            {
                await SignInUser(userName, role,userId,studentId);
                return true;
            }
            return false;
        }

        private async Task SignInUser(string userName, string role,Guid userId,Guid? studentId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier,userId.ToString()),
                new Claim(ClaimTypes.Anonymous,studentId.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        [HttpGet("/CreateParent")]
        public async Task <IActionResult> CreateParent()
        {
            var students =  await _studentServices.GetAllStudents(null);
            await _parentServices.CreateParent(students.ToList());
            return View();
        }
            [HttpGet("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
