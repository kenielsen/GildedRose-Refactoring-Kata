using GildedRoseKata;
using GildedRoseKata.Updater;
using Shouldly;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class BasicItemUpdaterShould
    {
        private readonly BasicItemUpdater _updater;

        public BasicItemUpdaterShould()
        {
            _updater = new BasicItemUpdater();
        }

        [Fact]
        public void CorrectlyDecrementSellIn()
        {
            var item = new Item
            {
                SellIn = 1
            };

            item = _updater.UpdateItem(item);
            item.SellIn.ShouldBe(0);
        }

        [Fact]
        public void DecreaseQualityBy1WhenSellInGreaterThanZero()
        {
            var item = new Item
            {
                SellIn = 1,
                Quality = 2
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Fact]
        public void DecreaseQualityBy2WhenSellInIsZero()
        {
            var item = new Item
            {
                SellIn = 0,
                Quality = 3
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Fact]
        public void DecreaseQualityBy2WhenSellInLessThanZero()
        {
            var item = new Item
            {
                SellIn = -1,
                Quality = 3
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        public void NeverDecreaseQualityBelowZero(int sellIn, int quality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(0);
        }
    }
}
