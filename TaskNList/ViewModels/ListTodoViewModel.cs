using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNList.Models;

namespace TaskNList.ViewModels
{
    public class ListTodoViewModel
    {
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}