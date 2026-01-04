using System.Text.Json;
using Microsoft.JSInterop;

namespace TIN.Frontend.Cart;

public class CartService(IJSRuntime js)
{
    private const string StorageKey = "Cart";

    public async Task AddToCart(CartItem cartItem)
    {
        var cart = await GetCartAsync();
        
        var item = cart.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
        
        if (item == null)
        {
            item = cartItem;
        }
        else
        {
            cart.Remove(item);
            item.Quantity++;
        }
        
        cart.Add(item);

        await WriteToStorage(cart);
    }
    
    public async Task DeleteFromCart(CartItem cartItem)
    {
        var cart = await GetCartAsync();
        
        var item = cart.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
        
        if (item == null)
        {
            return;
        }
        
        cart.Remove(item);
        item.Quantity--;
        
        if (item.Quantity > 0)
            cart.Add(item);

        await WriteToStorage(cart);
    }

    public async Task ClearCart()
    {
        await js.InvokeVoidAsync("localStorage.removeItem", StorageKey);
    }

    public async Task<List<CartItem>> GetCartAsync()
    {
        var json = await js.InvokeAsync<string>("localStorage.getItem", StorageKey);

        if (string.IsNullOrEmpty(json))
            return [];

        return JsonSerializer.Deserialize<List<CartItem>>(json)!;
    }

    private async Task WriteToStorage(List<CartItem> cart)
    {
        await js.InvokeVoidAsync("localStorage.setItem", StorageKey, JsonSerializer.Serialize(cart));
    }
}