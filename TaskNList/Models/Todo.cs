using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNList.Models
{
    public class Todo
    {


        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }

        public Todo(string title, DateTime date, bool isCompleted = false)
        {
            Title = title;
            Date = date;
            IsCompleted = isCompleted;
        }

        public Todo(int id, string title, DateTime date, bool isCompleted = false)
        {
            Id = id;
            Title = title;
            Date = date;
            IsCompleted = isCompleted;
        }
    }
}