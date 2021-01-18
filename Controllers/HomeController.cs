using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EPLAYERS_ASPNETCORE.Models;
using Microsoft.AspNetCore.Http;

namespace EPLAYERS_ASPNETCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag._UserName = HttpContext.Session.GetString("_UserName");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
