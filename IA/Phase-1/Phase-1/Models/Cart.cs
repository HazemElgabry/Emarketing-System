using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Phase_1.Models
{
    public class Cart
    {


        [Key]
        public int product_Id { get; set; }

        [ForeignKey("product_Id")]
        public Product Product { get; set; }

        public DateTime added_at { get; set; }


    }
}