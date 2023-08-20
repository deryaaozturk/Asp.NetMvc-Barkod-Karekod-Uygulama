using KarekodBarkodUygulaması.Models;
using KarekodBarkodUygulaması.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KarekodBarkodUygulaması.Controllers
{
    
    public class HomeController : Controller
    {
        private IProductsRepository repository;


        private readonly ILogger<HomeController> _logger;

        public HomeController(IProductsRepository repo)
        {
            repository = repo;
        }

        public IActionResult Index()
        {
            return View(new ProductsViewModel
            {
                Products = repository.Products
            });
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
    }
}
