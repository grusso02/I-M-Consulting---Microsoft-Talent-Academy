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
        public async Task<IActionResult> IndexAsync()
        {
            ViewData["Title"] = "Lista dei posts";
            var model = await _postDAL.GetPostsAsync();
            return View(model);
        }
    }
}
