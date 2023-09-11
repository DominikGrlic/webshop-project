using web_shop.Models;

namespace web_shop.Services.Cart;

public class CartItem
{
    public Product Product { get; set; }
    public decimal Quantity { get; set; }

    public decimal GetTotal()
    {
        return Product.Price * Quantity;
    }

}
