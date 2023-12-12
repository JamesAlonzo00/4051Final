using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model;

public class Item
{
    public string ItemName { get; set; }
    public decimal Price { get; set; }

    // Constructor to initialize an item with name, price, and add it to the inventory
    public Item(string itemName, decimal price, Inventory inventory)
    {
        ItemName = itemName;
        Price = price;
        inventory.AddItemToInventory(this); // Add this item to the specified inventory
    }
}
