using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserDAL _userDAL;
        public UsersController(IUserDAL userDAL)
        {
            this._userDAL = userDAL;
        }
        //Attribute based routing
        [HttpGet("listausers/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = _userDAL.Users.Where(u => !id.HasValue || u.id == id.Value);
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var user = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User model)
        {
            var user = _userDAL.Users.Where(u => u.id == model.id).SingleOrDefault();
            _userDAL.Users.Remove(user);
            _userDAL.Users.Add(model);
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            return View(user);
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
            var deleted = _userDAL.Users.Where(u => u.id == id).SingleOrDefault();
            _userDAL.Users.Remove(deleted);
            return RedirectToAction("Index");
        }
    }
}
