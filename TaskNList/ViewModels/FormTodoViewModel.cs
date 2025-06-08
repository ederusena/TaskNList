using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskNList.ViewModels
{
    public class FormTodoViewModel
    {   
        public int Id { get; set; }
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string Title { get; set; }

    }
}