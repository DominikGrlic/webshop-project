using Microsoft.AspNetCore.Mvc;
using web_shop.Data;
using web_shop.Services;
using web_shop.Services.Cart;

namespace web_shop.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContex _context;

        // Kljuc nase sesije za kosaricu
        public const string sessionCartKey = "_cart";
        
        public CartController(AppDbContex context)
        {
            _context = context;
        }

        // GET: Cart/Index
        public IActionResult Index()
        {
            // Provjera kosarice iz sesije
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson(sessionCartKey);

            // Provjera error poruke
            ViewBag.CartMsg = TempData["CartMsg"] as string ?? string.Empty;

            return View(cart);
        }

        // TODO: AddToCart (int productId, decimal quantity)
        [HttpPost]
        public IActionResult AddToCart(int productId, decimal quantity)
        {
            if(quantity <= 0)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            // 1.Provjeri ako postoji proizvod
            var findProduct = _context.Products.Find(productId);
            if(findProduct == null)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            // 2.Provjeri sesiju
            List<CartItem> cart = HttpContext.Session.GetObjectFromJson(sessionCartKey);

            // 3. Uvjeti koristenja kosarice
            if(cart.Count == 0)
            {
                if(quantity > findProduct.InStock)
                {
                    TempData["CartMsg"] = $"Nije moguće dodati proizvod u košaricu! Na zalihama je trenutno {findProduct.InStock}";
                    return RedirectToAction(nameof(Index));
                }

                // Kreiraj novi objekt klase cartItem i popuni ga podacima
                CartItem newItem = new CartItem()
                {
                    Product = findProduct,
                    Quantity = quantity
                };
                // Dodaj stavku u kolekciju kosarice
                cart.Add(newItem);
                // Azuriraj sesiju za kosaricu
                HttpContext.Session.SetObjectAsJason(sessionCartKey, cart);

            }
            else
            {

            }


            return RedirectToAction(nameof(Index));
        }


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
