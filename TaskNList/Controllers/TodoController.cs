using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNList.Context;
using TaskNList.ViewModels;

namespace TaskNList.Controllers
{
    public class TodoController : Controller
    {   
        private readonly AppDbContext _context;
        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var todos = _context.Todos.ToList();
            var viewModel = new ListTodoViewModel
            {
                Todos = todos
            };
            ViewData["Title"] = "Todo List";
            return View(viewModel);
        }
        
    }
}