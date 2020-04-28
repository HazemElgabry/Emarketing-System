using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Phase_1.Models
{
    public class Product
    {
         
        public int Id { get; set; }

        [Required(ErrorMessage = "* You must enter your product name")]
        [Display(Name = "Product Name:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* You must enter your product price")]
        [Display(Name = "Product Price:")]
        [Range(0, 10000000,ErrorMessage = "* Please enter a valid price")]
        public int Price { get; set; }

        [Required(ErrorMessage = "* Please upload your product image")]
        [Display(Name = "Product Image:")]
        public string Image { get; set; }
       
        [Display(Name = "Short description")]
        public string Description { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }


        public ICollection<Cart> carts { get; set; }
    }
}