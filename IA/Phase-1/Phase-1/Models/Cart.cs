using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Phase_1.Models
{
    public class Cart
    {
        public int id { get; set; }



        public int product_Id { get; set; }

        [ForeignKey("product_Id")]
        public Product product { get; set; }

        public DateTime added_at { get; set; }


    }
}