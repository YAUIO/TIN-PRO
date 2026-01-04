using System.Text.Json;
using Microsoft.JSInterop;

namespace TIN.Frontend.Cart;

public interface ICartService
{
    Task AddToCart(CartItem cartItem);

    Task DeleteFromCart(CartItem cartItem);
    
    Task ClearCart();

    Task<List<CartItem>> GetCartAsync();
}