using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;
        private const string SULFURAS = "Sulfuras";
        private const int SULFURAS_QUALITY = 80;
        private const string AGED_BRIE = "Aged Brie";
        private const string BACKSTAGE_PASSES = "Backstage passes";
        private const int MAX_QUALITY = 50;
        private const int MIN_QUALITY = 0;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private int CheckQuality(int quality)
        {
            if (quality > MAX_QUALITY)
            {
                return MAX_QUALITY;
            }

            if (quality < MIN_QUALITY)
            {
                return MIN_QUALITY;
            }

            return quality;
        }

        private int GetItemQuality(Item item)
        {
            if (item.Name.StartsWith(SULFURAS, StringComparison.CurrentCultureIgnoreCase))
            {
                return SULFURAS_QUALITY;
            }

            if (item.Name.Equals(AGED_BRIE, StringComparison.CurrentCultureIgnoreCase))
            {
                if (item.SellIn <= 0)
                {
                    return CheckQuality(item.Quality + 2);
                }
                return CheckQuality(item.Quality + 1);
            }

            if (item.Name.StartsWith(BACKSTAGE_PASSES, StringComparison.CurrentCultureIgnoreCase))
            {
                if (item.SellIn > 10)
                {
                    return CheckQuality(item.Quality + 1);
                }
                if (item.SellIn > 5)
                {
                    return CheckQuality(item.Quality + 2);
                }
                if (item.SellIn > 0)
                {
                    return CheckQuality(item.Quality + 3);
                }
                return 0;
            }

            if (item.SellIn > 0)
            {
                return CheckQuality(item.Quality - 1);
            }

            return CheckQuality(item.Quality - 2);
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                item.Quality = GetItemQuality(item);
                
                if (!item.Name.StartsWith(SULFURAS, StringComparison.CurrentCultureIgnoreCase))
                {
                    item.SellIn--;
                }
            }
        }
    }
}
