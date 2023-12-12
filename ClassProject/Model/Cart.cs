using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model;

public class Cart
{
    
    public List<Item> cartItems ;

    public Cart()
    {
        cartItems = new List<Item>();
        
    }

    public void AddItemToCart(string itemName, Inventory inventory)
    {
        List<Item> itemsInStock = inventory.GetItemsInStock();
        Item foundItem = itemsInStock.Find(item => item.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (foundItem != null)
        {
            cartItems.Add(foundItem);
            Console.WriteLine($"{itemName} added to cart.");
        }
        else
        {
            Console.WriteLine($"{itemName} not found in inventory.");
        }
    }

    public void DisplayCartItems()
    {
        Console.WriteLine("Items in Cart:");
        foreach (var item in cartItems)
        {
            Console.WriteLine($"- {item.ItemName} (${item.Price})");
        }
    }
}
