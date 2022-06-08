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
        public async Task<IActionResult> IndexAsync(int? id)
        {
            if (id.HasValue)
                ViewData["Header"] = id;
            else
                ViewData["Header"] = "id empty";
            var model = (await _userDAL.GetUsersAsync()).Where(p => !id.HasValue || p.id == id.Value);
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
    }
}
