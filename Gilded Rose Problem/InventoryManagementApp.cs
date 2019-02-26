using System;
using System.Collections.Generic;

namespace GildedRoseProblem
{
    public class InventoryManagementApp
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item("Aged Brie", 1, 1),
                new Item("Backstage passes", -1, 2),
                new Item("Backstage passes", 9, 2),
                new Item("Sulfuras", 2, 2),
                new Item("Normal Item", -1, 55),
                new Item("Normal Item", 2, 2),
                new Item("INVALID ITEM", 2, 2),
                new Item("Conjured", 2, 2),
                new Item("Conjured", -1, 5)
            };

            Inventory inventory = new Inventory(items);
            Console.WriteLine("Original Stock State:");
            Console.Write(inventory.ToString());

            inventory.UpdateQualityOfItems();
            Console.WriteLine("\nUpdated Stock State:");
            Console.Write(inventory.ToString());
            Console.Read();
        }
    }
}
