using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRoseProblem
{
    public class Item
    {
        public const int MAX_QUALITY = 50;
        public const int MIN_QUALITY = 0;

        private const string NORMAL_ITEM = "normal item";
        private const string AGED_BRIE = "aged brie";
        private const string BACKSTAGE_PASSES = "backstage passes";
        private const string CONJURED = "conjured";
        private const string SULFURAS = "sulfuras";

        private const int DEFAULT_DECREMENT = 1;

        public string Name { get; private set; }
        public int SellIn { get; private set; }
        public int Quality { get; private set; }

        public Item(String name, int sellIn, int quality)
        {
            this.Name = name;
            this.SellIn = sellIn;
            this.Quality = quality;
        }

        public void UpdateQuality()
        {
            string nameLowerCase = Name.ToLower();
            if (nameLowerCase == NORMAL_ITEM || nameLowerCase == CONJURED ||
                nameLowerCase == AGED_BRIE || nameLowerCase == BACKSTAGE_PASSES)
            {
                SellIn -= DEFAULT_DECREMENT;
            }
            
            int decrement = GetQualityDecrement();
            
            switch (Name.ToLower())
            {
                case NORMAL_ITEM:
                case CONJURED:
                    Quality -= decrement;
                    break;
                case AGED_BRIE:
                case BACKSTAGE_PASSES:
                    Quality += decrement;
                    break;
            }

            ClampQuality();
        }

        private int GetQualityDecrement()
        {
            int decrement = DEFAULT_DECREMENT;
            if(Name.ToLower() == BACKSTAGE_PASSES)
            {
                if (SellIn < 0)
                {
                    decrement = Quality;
                }
                else if(SellIn <= 5)
                {
                    decrement *= 3;
                }
                else if (SellIn <= 10)
                {
                    decrement *= 2;
                }
            }
            else if(SellIn < 0)
            {
                decrement *= 2;
            }

            if(Name.ToLower() == CONJURED)
            {
                decrement *= 2;
            }

            return decrement;
        }

        private void ClampQuality()
        {
            if(Quality > MAX_QUALITY)
            {
                Quality = MAX_QUALITY;
            }
            else if(Quality < MIN_QUALITY)
            {
                Quality = MIN_QUALITY;
            }
        }
    }
}
