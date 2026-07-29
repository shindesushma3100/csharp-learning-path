using System.Collections.Generic;

class Product
{
    public string Name;
    public double Price;

    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }
}

class CartItem
{
    public Product Product;
    public int Quantity;

    public CartItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double GetSubtotal() => Product.Price * Quantity;
}

class ShoppingCart
{
    private List<CartItem> items = new List<CartItem>();

    public void AddItem(Product product, int quantity)
    {
        CartItem existing = items.Find(i => i.Product.Name == product.Name);
        if (existing != null)
        {
            existing.Quantity += quantity;
            Console.WriteLine($"Increased {product.Name} quantity to {existing.Quantity}");
        }
        else
        {
            items.Add(new CartItem(product, quantity));
            Console.WriteLine($"Added {quantity} x {product.Name} to cart");
        }
    }

    public void RemoveItem(string productName)
    {
        CartItem item = items.Find(i => i.Product.Name == productName);
        if (item != null)
        {
            items.Remove(item);
            Console.WriteLine($"Removed {productName} from cart");
        }
        else
        {
            Console.WriteLine($"{productName} not found in cart");
        }
    }

    public void ShowCart()
    {
        Console.WriteLine("\n-- Cart Contents --");
        double total = 0;
        foreach (var item in items)
        {
            double subtotal = item.GetSubtotal();
            Console.WriteLine($"{item.Product.Name} x{item.Quantity} = {subtotal}");
            total += subtotal;
        }
        Console.WriteLine($"Total: {total}");
    }
}

class Program
{
    static void Main()
    {
        ShoppingCart cart = new ShoppingCart();

        Product laptop = new Product("Laptop", 55000);
        Product mouse = new Product("Mouse", 500);

        cart.AddItem(laptop, 1);
        cart.AddItem(mouse, 2);
        cart.AddItem(mouse, 1); // should increase quantity, not duplicate

        cart.ShowCart();

        cart.RemoveItem("Mouse");
        cart.ShowCart();
    }
}