using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_shop.Data;
using web_shop.Models;

namespace web_shop.Controllers
{
    [Authorize] // primjenjuje se na cijeli kontroler ili na akcije unutar kontrolera
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContex _dbContext;
        // dependency injection za objekt klase AppDbContext                                                                        <-------------------
        public HomeController(ILogger<HomeController> logger, AppDbContex dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string? homeSearch, int orderBy = 0, int? categoryId = 0)
        {            
            List<Product> products = _dbContext.Products.ToList();

            if(categoryId > 0)
            {
                products = products.Where(p => _dbContext.ProductCategories.Where(pc => pc.CategoryId == categoryId).Select(pc => pc.ProductId).ToList().Contains(p.Id)).ToList();
            }

            // ako parametar "homeSearch" nije prazan, filtriraj proizvode (po naslovu)
            if (!string.IsNullOrWhiteSpace(homeSearch))
            {
                return View(products.Where(a => a.Title.ToLower().Contains(homeSearch.ToLower())).ToList());
            }

            switch ((int)orderBy)
            {
                case 1: products = products.OrderBy(a => a.Title).ToList(); break;
                case 2: products = products.OrderByDescending(a => a.Title).ToList(); break;
                case 3: products = products.OrderBy(a => a.Price).ToList(); break;
                case 4: products = products.OrderByDescending(a => a.Price).ToList(); break;
            }

            // Lista kategorija
            ViewBag.CategoriesVB = _dbContext.Categories.ToList();

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
    }
}