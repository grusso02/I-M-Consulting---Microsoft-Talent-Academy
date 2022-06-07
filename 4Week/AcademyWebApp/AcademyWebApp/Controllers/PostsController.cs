﻿using Infrastructure;
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
        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = (await _postDAL.GetPostsAsync()).Where(p => !id.HasValue || p.userId == id.Value);
            return View(model);
        }
    }
}
