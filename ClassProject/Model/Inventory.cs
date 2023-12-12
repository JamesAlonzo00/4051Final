using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model;

public class Inventory
{
    private List<Item> itemsInStock;//declares a referance variable for a list

    public Inventory() //constructor that 
    {
        itemsInStock = new List<Item>(); //assigns reference variable to a new list
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
            Console.WriteLine($"- {item.ItemName} (${item.Price})"); //prints each item separately
        }
    }
    public List<Item> GetItemsInStock()// not directly used but would return a list
    {
        return itemsInStock;
    }
}
