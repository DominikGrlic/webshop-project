using Newtonsoft.Json;
using web_shop.Services.Cart;

namespace web_shop.Services;

public static class SessionExtensions
{
    public static void SetObjectAsJason(this ISession session, string key, object value)
    {
        session.SetString(key, JsonConvert.SerializeObject(value));
    }

    public static List<CartItem> GetObjectFromJson(this ISession session, string key)
    {
        var value = session.GetString(key);
        return value == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(value);
    }
}
