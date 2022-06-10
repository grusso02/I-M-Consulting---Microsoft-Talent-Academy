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
        public IActionResult Index(int? id, int? colId, string CurrentSort)
        {
            CurrentSort = String.IsNullOrEmpty(CurrentSort) ? "ASC" : CurrentSort;
            colId = colId == null ? 0 : colId;
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = _userDAL.Users.Where(u => !id.HasValue || u.id == id.Value);
            switch (colId)
            {
                case 1:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.id) : model.OrderBy(m => m.id);
                    break;
                case 2:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.name) : model.OrderBy(m => m.name);
                    break;
                case 3:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.username) : model.OrderBy(m => m.username);
                    break;
                case 4:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.email) : model.OrderBy(m => m.email);
                    break;
                case 5:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.phone) : model.OrderBy(m => m.phone);
                    break;
                case 6:
                    model = CurrentSort == "DESC" ? model.OrderByDescending(m => m.website) : model.OrderBy(m => m.website);
                    break;
                case 0:
                    model = model.OrderBy(m => m.name);
                    break;
            }
            ViewBag.CurrentSort = CurrentSort == "DESC" ? "ASC" : "DESC";
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
