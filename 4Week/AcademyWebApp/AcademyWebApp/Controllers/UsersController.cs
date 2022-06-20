using AcademyWebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AcademyWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserDAL _userDAL;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signinManager;

        public UsersController(IUserDAL userDAL, UserManager<User> userManager, SignInManager<User> signinManager)
        {
            this._userDAL = userDAL;
            this._userManager = userManager;
            this._signinManager = signinManager;
        }
        //Attribute based routing
        [HttpGet("listausers/{id:int?}")]
        public IActionResult Index(int? id, int? colId, string CurrentSort)
        {
            //CurrentSort = String.IsNullOrEmpty(CurrentSort) ? "ASC" : CurrentSort;
            //colId = colId == null ? 0 : colId;
            //if (id.HasValue)
            //    ViewData["Header"] = id;
            //else
            //    ViewData["Header"] = "id empty";
            //var model = _userDAL.Users.Where(u => !id.HasValue || u.id == id.Value);
            //switch (colId)
            //{
            //    case 1:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.id) : model.OrderBy(m => m.id);
            //        break;
            //    case 2:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.name) : model.OrderBy(m => m.name);
            //        break;
            //    case 3:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.username) : model.OrderBy(m => m.username);
            //        break;
            //    case 4:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.email) : model.OrderBy(m => m.email);
            //        break;
            //    case 5:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.phone) : model.OrderBy(m => m.phone);
            //        break;
            //    case 6:
            //        model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.website) : model.OrderBy(m => m.website);
            //        break;
            //    case 0:
            //        model = model.OrderBy(m => m.name);
            //        break;
            //}
            //ViewBag.CurrentSort = CurrentSort == "DESC" ? "ASC" : "DESC";
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var user = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            return View();
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            //var user = _userDAL.Users.Where(u => u.id == model.id).SingleOrDefault();
            //_userDAL.Users.Remove(user);
            //_userDAL.Users.Add(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            //var user = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            _userDAL.Users.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            //var deleted = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            //_userDAL.Users.Remove(deleted);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.UserName, UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login([FromQuery]string ReturnUrl)
        {
            return View(new LoginViewModel { ReturnUrl = ReturnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(model.ReturnUrl);
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ForgotPasswordViewModel model = new ForgotPasswordViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPasswordAsync(ForgotPasswordViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            string token = "";
            if (user != null)
            {
                token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
                return Redirect($"/Users/ResetPassword/?token={token}");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ResetPassword([FromQuery] string token)
        {
            var model = new PasswordResetViewModel { Token = token };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(PasswordResetViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var reset = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                if (reset.Succeeded)
                    return RedirectToAction("Login");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> LogoutAsync()
        {
            if (User.Identity.IsAuthenticated)
                await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
