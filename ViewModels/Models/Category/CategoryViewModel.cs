using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Models.Category
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
