using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model;

public class Inventory
{
    private List<Item> itemsInStock;

    public Inventory()
    {
        itemsInStock = new List<Item>();
    }

    // Method to add an item to the inventory
    public void AddItemToInventory(Item item)
    {
        itemsInStock.Add(item);
    }

    // Method to display all items in stock
    public void DisplayAllItemsInStock()
    {
        Console.WriteLine("Items in Stock:");
        foreach (var item in itemsInStock)
        {
            Console.WriteLine($"- {item.ItemName} (${item.Price})");
        }
    }
    public List<Item> GetItemsInStock()
    {
        return itemsInStock;
    }
}
