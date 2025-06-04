using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskNList.Models;

namespace TaskNList.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to the Test Page!";

            var todo = new Todo { Title = "Sample Task", Description = "This is a sample task description." };

            ViewBag.Todo = todo;

            TempData["TempMessage"] = "This is a temporary message that will disappear after the next request.";


            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}