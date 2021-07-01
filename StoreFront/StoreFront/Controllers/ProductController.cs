using Microsoft.AspNetCore.Mvc;
using StoreFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Controllers
{
    public class ProductController : Controller
    {

        ProductsContext db = new ProductsContext();
        public IActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
            
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult Result(Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }


        public IActionResult Delete(int id)
        {
            Product P = db.Products.Find(id);
            return View(P);
        }

        public IActionResult ReplenishStock()
        {
            List<Product> products = db.Products.ToList();

            foreach(Product p in products)
            {
                if (p.Quantity<10)
                {
                    p.Quantity = 10;
                }
            }
            return RedirectToAction("Index", "Storefront");
        }

        public IActionResult ConfirmDelete(int id)
        {
            Product P = db.Products.Find(id);
            db.Remove(P);
            db.SaveChanges();
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Update(int id)
        {
            Product P = db.Products.Find(id);
            return View(P);
        }

        public IActionResult Details(int id)
        {
            Product P = db.Products.Find(id);
            return View(P);
        }
    }
}
