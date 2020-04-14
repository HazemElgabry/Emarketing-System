using Phase_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phase_1.Models;
using System.IO;

namespace Phase_1.Controllers.ProjectControllers
{
    public class ProductsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();       
        // GET: Products
        public ActionResult Index()
        {
            var products = db.products;

            return View(products.ToList());
        }
        
        // ------------------------- Show Product details ----------------------            
        public ActionResult ProductDetails()
        {                                  
            return View();
        }        

        // ---------------------- Adding Product -----------------------
        [HttpGet]
        public ActionResult AddProduct()
        {
            var Categories = db.categories.ToList();
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Categories = Categories
            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult AddProduct(CategoryViewModel cvm, HttpPostedFileBase file)
        {

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images/"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);                    
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "You have not specified a file.";
            }


            cvm.Product.Image = file.FileName;


            db.products.Add(cvm.Product);
            db.SaveChanges();
            return RedirectToAction("AddProduct");
        }

        // ------------------------------------ Updating Product -------------------
        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var Product = db.products.Single(c => c.Id == id);
            var Categories = db.categories.ToList();
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Categories = Categories,
                Product = Product
            };

            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct()
        {
            return View();
        }
    }
}