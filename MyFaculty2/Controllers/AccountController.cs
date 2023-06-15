using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyFaculty2.Models;
using MyFaculty2.ViewModels;
using System.Diagnostics;

namespace MyFaculty2.ViewModels
{
    public class AccountController : Controller
    {
        private readonly MyFacultyDbContext _context;

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, SignInManager<User> signInManager, MyFacultyDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return (_userManager.Users != null) ?
                          View(await _userManager.Users.ToListAsync()) :
                          Problem("There is no users in system");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = (_userManager.Users != null) ?
                          await _userManager.Users.FirstOrDefaultAsync(m => m.Id == id) :
                          null;
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }


        // GET: Accounts/RegisterTeacher
        [HttpGet]
        public IActionResult RegisterTeacher()
        {
            var teachers = _context.Teachers.Where(a => a.UserId == null).Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.Surname + " " + a.Name + " " + a.LastName
                                  }).ToList();
            ViewData["TeachersList"] = teachers;
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(RegisterTeacherViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            var teacher = _context.Teachers.FirstOrDefault(a => a.Id == model.TeacherId);
            if (teacher == null)
                return View(model);
            User user = new User { Email = model.Email, UserName = model.Email, BirthDate = model.Date, TeacherId = model.TeacherId };
            
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                await _userManager.AddToRoleAsync(user, "teacher");
                teacher.UserId = user.Id;
                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);

        }

        // GET: Accounts/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Groups");
                }
            }
            else
            {
                ModelState.AddModelError("", "Неправильний логін і(або) пароль");
            }
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}