using GildedRoseKata;
using GildedRoseKata.Updater;
using Shouldly;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class LegendaryItemUpdaterShould
    {
        private readonly LegendaryItemUpdater _updater;

        public LegendaryItemUpdaterShould()
        {
            _updater = new LegendaryItemUpdater();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void AlwaysSetQualityTo80(int sellIn)
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = sellIn,
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(80);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void NeverDecrementSellIn(int sellIn)
        {
            var item = new Item
            {
                SellIn = sellIn
            };

            item = _updater.UpdateItem(item);

            item.SellIn.ShouldBe(sellIn);
        }
    }
}
