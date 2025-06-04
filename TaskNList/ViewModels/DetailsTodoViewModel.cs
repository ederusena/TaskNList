using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskNList.Models;

namespace TaskNList.ViewModels
{
    public class DetailsTodoViewModel
    {
        public Todo Todo { get; set; } = null!;
        public string PageTitle { get; set; } = string.Empty;
    }
}