using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;

namespace GuitarShop.Controllers
{
    public class ProductController : Controller
    {
        private ShopContext context;

        public ProductController(ShopContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Product");
        }
        [Route("[controller]s/{id?}")]
        public IActionResult List(string id = "All")
        {
            var categories = context.Categories
                .OrderBy(c => c.CategoryID).ToList();

            List<Product> product;
            if (id == "All")
            {
                product = context.Products
                    .OrderBy(p => p.ProductID).ToList();
            }

            // New condition for handling the "Strings" category
            else if (id == "Strings") 
            {
                product = context.Products
                    .Where(p => p.Category.Name == "Guitars" || p.Category.Name == "Basses")
                    .OrderBy(p => p.ProductID).ToList();
            }
            else
            {
                product = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductID).ToList();
            }

            // Use ViewBag to pass data to the view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // Bind products to view
            return View(product);
        }



    }
}