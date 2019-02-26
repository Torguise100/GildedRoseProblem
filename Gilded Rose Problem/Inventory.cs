using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseProblem
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory(List<Item> items)
        {
            this.items = items;
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void AddItem(string name, int sellIn, int quality)
        {
            AddItem(new Item(name, sellIn, quality));
        }

        public void AddItem(Item item)
        {
            if (item != null)
            {
                items.Add(item);
            }
            else
            {
                throw new NullReferenceException("Cannot add a null item to Inventory");
            }
        }

        public void UpdateQualityOfItems()
        {
            foreach(Item i in items)
            {
                i.UpdateQuality();
            }
        }

        public override String ToString()
        {
            string output = "";

            foreach(Item i in items)
            {
                output += i.ToString() + "\n";
            }

            return output;
        }
    }
}
