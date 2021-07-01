using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreFront.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace StoreFront.Controllers
{

    public class StorefrontController : Controller
    {
        ProductsContext db = new ProductsContext();

        public IActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Buy(int id)
        {
            
            Product P =  db.Products.Find(id);
            return View(P);
        }

        public IActionResult ConfirmBuy(int id)
        {
            Product P = db.Products.Find(id);
            P.Quantity--;
            db.SaveChanges();
            return RedirectToAction("Index","Storefront");
        }

    }
}
