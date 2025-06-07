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

        public IActionResult Create()
        {
            ViewData["Title"] = "Create Todo";
            return View();
        }

        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
            {
                return NotFound();
            }
            _context.Todos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}