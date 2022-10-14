using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;
using System.Text.Json;

namespace MVC_Demo.Controllers
{
    public class ProductsController : Controller
    {
        private IEnumerable<ProductsViewModel> products
            = new List<ProductsViewModel>()
            {
                new ProductsViewModel()
                {
                    Id = 1,
                    Name = "Cheese",
                    Price = 10.20
                },
                 new ProductsViewModel()
                {
                    Id = 2,
                    Name = "Ham",
                    Price = 3.50
                },
                  new ProductsViewModel()
                {
                    Id = 3,
                    Name = "Bread",
                    Price = 1.99
                },

            };
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            return View(this.products);
        }

        public IActionResult ById(int id)
        {
            var product = this.products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return BadRequest();
            }
            return View(product);
        }

        public IActionResult AllAsJson()
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            return Json(products, options);
        }

        public IActionResult AllAsText()
        {
            var text = string.Empty;
            foreach (var product in products)
            {
                text += $"Product {product.Id}: {product.Name} - {product.Price}lv.";
                text += Environment.NewLine;
            }
            return Content(text);
        }
    }
}
