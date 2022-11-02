using System;
using System.Linq;

namespace GildedRoseKata.Updater
{
    public static class ItemUpdaterFactory
    {
        private static string[] _legendaryItemNamesStartWith = new string[] { "Sulfuras" };
        private static readonly string[] _agingItemNames = new string[] { "Aged Brie" };
        private static readonly string[] _timeSensitiveItemNamesStartWith = new string[] { "Backstage passes" };
        private static readonly string[] _conjuredItemNamesStartWith = new string[] { "Conjured" };

        public static AbstractItemUpdater GetUpdater(string itemName)
        {
            if (_agingItemNames.Contains(itemName, StringComparer.CurrentCultureIgnoreCase))
            {
                return new AgingItemUpdater();
            }

            if (_legendaryItemNamesStartWith.Any(name => itemName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return new LegendaryItemUpdater();
            }

            if (_timeSensitiveItemNamesStartWith.Any(name => itemName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return new TimeSensitiveItemUpdater();
            }

            if (_conjuredItemNamesStartWith.Any(name => itemName.StartsWith(name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return new ConjuredItemUpdater();
            }

            return new BasicItemUpdater();
        }
    }
}
