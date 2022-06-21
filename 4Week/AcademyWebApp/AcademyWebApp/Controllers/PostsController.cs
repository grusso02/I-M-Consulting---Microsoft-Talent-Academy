using AcademyWebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace AcademyWebApp.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class PostsController : Controller
    {
        private readonly IPostDAL _postDAL;
        private readonly IUserDAL _userDAL;

        public PostsController(IPostDAL postDAL, IUserDAL userDAL)
        {
            this._postDAL = postDAL;
            this._userDAL = userDAL;
        }
        //Attribute based routing
        [HttpGet("listaposts/{id:int?}")]
        public IActionResult Index(int? id, int? page)
        {
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = _postDAL.Posts.Where(p => !id.HasValue || p.userId == id.Value).OrderBy(p => p.id).ToPagedList(page ?? 1, 10);
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postDAL.Posts.Where(p => p.id == id).SingleOrDefault();
            var users = _userDAL.Users.OrderBy(u => u.name);
            PostViewModel model = new PostViewModel
            {
                Item = post,
                Users = new SelectList(users, "id", "name")
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(PostViewModel model)
        {
            var post = _postDAL.Posts.Where(p => p.id == model.Item.id).SingleOrDefault();
            _postDAL.Posts.Remove(post);
            _postDAL.Posts.Add(model.Item);
            model.Users = new SelectList(_userDAL.Users.OrderBy(u => u.name), "id", "name");
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var post = _postDAL.Posts.Where(p => p.id == id).SingleOrDefault();
            return View(post);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Post model)
        {
            _postDAL.Posts.Add(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deleted = _postDAL.Posts.Where(p => p.id == id).SingleOrDefault();
            _postDAL.Posts.Remove(deleted);
            return RedirectToAction("Index");
        }
    }
}
