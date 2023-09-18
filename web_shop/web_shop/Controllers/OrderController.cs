using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using web_shop.Models;
using web_shop.Services;
using web_shop.Services.Cart;

namespace web_shop.Controllers;

public class OrderController : Controller
{
    public const string sessionCartKey = "_cart";

    // GET: Order/Checkout
    public IActionResult Checkout()
    {
        List<CartItem> cart = HttpContext.Session.GetObjectFromJson(sessionCartKey);

        if(cart.Count <= 0)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.CheckoutMsg = TempData["CheckoutMsg"] as string ?? string.Empty;

        return View(cart);
    }

    //-- TODO: CreateOrder(Order newOrder)
    [HttpPost]
    public IActionResult CreateOrder(Order newOrder)
    {

        //-- Provjera ako je kosarica prazna
        List<CartItem> cart = HttpContext.Session.GetObjectFromJson(sessionCartKey);

        if(cart.Count <= 0)
        {
            return RedirectToAction("Index", "Home");
        }

        var modelErrors = new List<string>();

        if(ModelState.IsValid)
        {
            //-- sva svojstva su validna
        }
        else
        {
            foreach(var modelState in ModelState.Values)
            {
                foreach(var error in modelState.Errors)
                {
                    modelErrors.Add(error.ErrorMessage);
                }
            }

            TempData["CheckoutMsg"] = String.Join("<br />", modelErrors);

            return RedirectToAction(nameof(Checkout));
        }

        return View();
    }
}
