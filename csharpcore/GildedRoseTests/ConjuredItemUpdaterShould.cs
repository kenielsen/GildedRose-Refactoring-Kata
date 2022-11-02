using GildedRoseKata;
using GildedRoseKata.Updater;
using Shouldly;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class ConjuredItemUpdaterShould
    {
        private readonly ConjuredItemUpdater _updater;
        public ConjuredItemUpdaterShould()
        {
            _updater = new ConjuredItemUpdater();
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
        public void DecreaseQualityBy2WhenSellInGreaterThanZero()
        {
            var item = new Item
            {
                Quality = 3,
                SellIn = 1
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Fact]
        public void DecreaseQualityBy4WhenSellInIsZero()
        {
            var item = new Item
            {
                Quality = 5,
                SellIn = 0
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Fact]
        public void DecreaseQualityBy4WhenSellInLessThanZero()
        {
            var item = new Item
            {
                Quality = 5,
                SellIn = -1
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 2)]
        [InlineData(0, 3)]
        [InlineData(-1, 0)]
        [InlineData(-1, 1)]
        [InlineData(-1, 2)]
        [InlineData(-1, 3)]
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
