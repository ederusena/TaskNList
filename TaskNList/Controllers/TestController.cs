using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskNList.Models;
using TaskNList.ViewModels;

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

        public IActionResult ViewModel()
        {
            var todo = new Todo { Title = "Estudar C#", Description = "Vai estudar seu vagabundo!" };
            var viewModel = new DetailsTodoViewModel
            {
                Todo = todo,
                PageTitle = "Task Details"
            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}