using Microsoft.AspNetCore.Mvc;

namespace web_shop.Controllers
{
    public class CartController : Controller
    {

        // GET: Cart/Index
        public IActionResult Index()
        {


            return View();
        }

        // TODO: AddToCart (int productId, decimal quantity)

        // TODO: RemoveFromCart (int productId)

        // GET: TestSession()
        public IActionResult TestSession()
        {

            // Jednostavan primjer dodavanje sesije po kljucu i vrijednosti
            HttpContext.Session.SetString("sessionString", "Ovo je moja vrijednost za string");

            ViewBag.ReadSessionString = HttpContext.Session.GetString("sessionString");

            HttpContext.Session.SetString("sessionString", "Neki drugi tekst!");

            return View();
        }
    }
}
