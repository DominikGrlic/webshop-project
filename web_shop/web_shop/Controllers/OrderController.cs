using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using web_shop.Areas.Identity.Data;
using web_shop.Data;
using web_shop.Models;
using web_shop.Services;
using web_shop.Services.Cart;

namespace web_shop.Controllers;

public class OrderController : Controller
{
    public const string sessionCartKey = "_cart";

    //-- Pristup bazi podataka
    private readonly AppDbContex _context;
    //-- Pristup trenutnom korisniku
    private readonly UserManager<AppUser> _user;

    public OrderController(AppDbContex context, UserManager<AppUser> user)
    {
        _context = context;
        _user = user;
    }

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
            newOrder.Subtotal = 0;
            newOrder.Tax = 0;
            newOrder.Total = cart.Sum(item => item.GetTotal());

            newOrder.UserId = _user.GetUserId(User);
            _context.Orders.Add(newOrder);
            _context.SaveChanges();

            foreach(var item in cart)
            {
                OrderItem newOrderItem = new OrderItem()
                {
                    OrderId = newOrder.Id,
                    ProductId = item.Product.Id,
                    Price = item.Product.Price,
                    Quantity = item.Quantity,
                    Total = item.GetTotal()
                };

                _context.OrderItems.Add(newOrderItem);
            }

            _context.SaveChanges();
            HttpContext.Session.SetObjectAsJason(sessionCartKey, "");

            TempData["ThanksMsg"] = "Thank you, your order will be processed quickly!";
            return RedirectToAction("Index", "Home");
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

    }
}
