using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostDAL _postDAL;
        public PostsController(IPostDAL postDAL)
        {
            this._postDAL = postDAL;
        }
        //Attribute based routing
        [HttpGet("listaposts/{id:int?}")]
        public IActionResult Index(int? id)
        {
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = _postDAL.Posts.Where(p => !id.HasValue || p.userId == id.Value).OrderByDescending(p => p.id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postDAL.Posts.Where(p => p.id == id).SingleOrDefault();
            return View(post);
        }
        [HttpPost]
        public IActionResult Edit(Post model)
        {
            var post = _postDAL.Posts.Where(p => p.id == model.id).SingleOrDefault();
            _postDAL.Posts.Remove(post);
            _postDAL.Posts.Add(model);
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
