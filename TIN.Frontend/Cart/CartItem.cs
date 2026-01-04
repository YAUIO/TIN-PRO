namespace TIN.Frontend.Cart;

public class CartItem
{
    public Guid ProductId { get; init; }
    
    public string Name { get; init; }
    
    public string ImageUri { get; init; }
    
    public int Quantity { get; set; }
    
    public decimal UnitPrice { get; set; }

    public decimal Price => Quantity * UnitPrice;
}