using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskNList.Context;
using TaskNList.Models;
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
            ViewData["Title"] = "Create Task";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(FormTodoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newTodo = new Todo(
                title: model.Title,
                date: DateTime.Now,
                isCompleted: false
            );

            _context.Todos.Add(newTodo);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            ViewData["Title"] = "Edit Task";
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
                return NotFound();

            var viewModel = new FormTodoViewModel
            {
                Id = todo.Id,
                Title = todo.Title,
            };

            return View("Form", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(FormTodoViewModel model)
        {
            var todo = _context.Todos.Find(model.Id);
            if (todo == null)
                return NotFound();

            todo.Title = model.Title;
            _context.Todos.Update(todo);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
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

        public IActionResult Complete(int id)
        {
            var todo = _context.Todos.FirstOrDefault(t => t.Id == id);
            if (todo is null)
                return NotFound();

            todo.IsCompleted = true;
            _context.Todos.Update(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}