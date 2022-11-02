using GildedRoseKata.Updater;
using Shouldly;
using System;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class ItemUpdaterFactoryShould
    {
        [Theory]
        [InlineData("Aged Brie", typeof(AgingItemUpdater))]
        [InlineData("Test item", typeof(BasicItemUpdater))]
        [InlineData("Conjured Maul of the Rat King", typeof(ConjuredItemUpdater))]
        [InlineData("Sulfuras, Hand of Ragnaros", typeof(LegendaryItemUpdater))]
        [InlineData("Backstage passes for XYZ concert", typeof(TimeSensitiveItemUpdater))]
        public void CreateCorrectItemUpdater(string itemName, Type updaterType)
        {
            var updater = ItemUpdaterFactory.GetUpdater(itemName);

            updater.ShouldBeOfType(updaterType);
        }
    }
}
