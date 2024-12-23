﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using GuitarShop.Models;
using System;

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

            // New condition for handling the "Strings" category step 10
            if (id == "All")
            {
                product = context.Products
                    .OrderBy(p => p.ProductID).ToList();
            }
            else if (id == "Strings")
            {
                // Debugging: Log when "Strings" condition is hit
                Console.WriteLine("Fetching stringed instruments...");

                product = context.Products
                    .Where(p => p.Category.IsStringedInstrument) 
                    .OrderBy(p => p.ProductID)
                    .ToList();
            }
            // Handle other categories dynamically by matching category names
            else
            {
                product = context.Products
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.ProductID).ToList();
            }

            // Use ViewBag to pass data to the view
            ViewBag.Categories = categories;

            // Modify ViewBag.SelectedCategoryName to handle "Strings" step 11
            ViewBag.SelectedCategoryName = id;

            if (id == "Strings")
            {
                ViewBag.SelectedCategoryName = "Strings";
            }

            // Bind products to view
            return View(product);
        }
    }
}
