using Phase_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Phase_1.ViewModels
{
    public class CategoryViewModel
    {
        public Product Product { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}