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

        // ------------------- Filter ----------------------
        public ActionResult Filter(int id)
        {
            var p = db.products.Where(c => c.CategoryID == id);

            return View(p.ToList());
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
            var Categories = db.categories.ToList();

            if (file != null && file.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Images"),Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    cvm.Product.Image = file.FileName;
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                if (!ModelState.IsValid)
                {
                    cvm.Categories = Categories;
                    return View("AddProduct", cvm);

                }
            }
                       
            db.products.Add(cvm.Product);

            
            var v = db.categories.Single(c => c.Id == cvm.Product.CategoryID);
            v.Number_of_products++;
            
            db.SaveChanges();
            return RedirectToAction("AddProduct");
        }        

        // ------------------------- Show Product details ----------------------
        public ActionResult ProductDetails(int Id)
        {
            var product = db.products.Where(c => c.Id == Id);

            return View(product.ToList()[0]);
        }


        // ------------------------------------ Updating Product -------------------
        [HttpGet]
        public ActionResult UpdateProduct(int Id)
        {
            var Product = db.products.Single(c => c.Id == Id);

            var Categories = db.categories.ToList();
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Categories = Categories,
                Product = Product
            };

            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(CategoryViewModel cvm)
        {

            var Categories = db.categories.ToList();
            if (!ModelState.IsValid)
            {
                cvm.Categories = Categories;
                return View("UpdateProduct", cvm);

            }

            var CustomerDB = db.products.Single(c => c.Id == cvm.Product.Id);

            CustomerDB.Name = cvm.Product.Name;
            CustomerDB.Price = cvm.Product.Price;
            CustomerDB.Image = cvm.Product.Image;
            CustomerDB.Description = cvm.Product.Description;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // ------------------------------------Delete Product ----------------------
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = db.products.Find(id);
            var Categories = db.categories.ToList();
            CategoryViewModel cvm = new CategoryViewModel()
            {
                Product = product,
                Categories = Categories
            };

            var v = db.categories.Single(c => c.Id == cvm.Product.CategoryID);
            v.Number_of_products--;


            if (product != null)
            {
                db.products.Remove(product);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}