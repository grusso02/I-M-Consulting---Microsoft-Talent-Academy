using AcademyWebApp.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRandomService _randomService;
        private readonly IRandomWrapper _randomWrapper;

        public HomeController(ILogger<HomeController> logger
            , IRandomService randomService
            , IRandomWrapper randomWrapper)
        {
            _logger = logger;
            this._randomService = randomService;
            this._randomWrapper = randomWrapper;
        }

        public IActionResult Index()
        {
            string message = $"Wrapper è {_randomWrapper.GenerateNumber()}\nService è: {_randomService.GenerateNumber()}";
            var model = new HomeViewModel { Heading = "Dependency Injection Test", Body = message };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
