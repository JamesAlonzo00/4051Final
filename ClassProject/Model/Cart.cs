using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model;

public class Cart
{
    
    public List<Item> cartItems ;//declares a reference variable for a list

    public Cart()
    {
        cartItems = new List<Item>();//assigns reference varibale to a new list
        
    }

    public void AddItemToCart(string itemName, Inventory inventory)// method that adds items to the cart using their name and the list they are going to
    {
        List<Item> itemsInStock = inventory.GetItemsInStock();
        Item foundItem = itemsInStock.Find(item => item.ItemName.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (foundItem != null)
        {
            cartItems.Add(foundItem);
            Console.WriteLine($"{itemName} added to cart.");//if else statement to check if the item is in stock or not
        }
        else
        {
            Console.WriteLine($"{itemName} not found in inventory.");
        }
    }

    public void DisplayCartItems()//prints each item in the cart one by one with price
    {
        Console.WriteLine("Items in Cart:");
        foreach (var item in cartItems)
        {
            Console.WriteLine($"- {item.ItemName} (${item.Price})");
        }
    }
}
