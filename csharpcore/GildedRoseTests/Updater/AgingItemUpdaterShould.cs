using GildedRoseKata;
using GildedRoseKata.Updater;
using Shouldly;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class AgingItemUpdaterShould
    {
        private readonly AgingItemUpdater _updater;
        public AgingItemUpdaterShould()
        {
            _updater = new AgingItemUpdater();
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
        public void IncreaseQualityBy1WhenSellInGreaterThanZero()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 1
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(1);
        }

        [Fact]
        public void IncreaseQualityBy2WhenSellInIsZero()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = 0
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(2);
        }

        [Fact]
        public void IncreaseQualityBy2WhenSellInLessThanZero()
        {
            var item = new Item
            {
                Quality = 0,
                SellIn = -1
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(2);
        }

        [Theory]
        [InlineData(1, 50)]
        [InlineData(0, 49)]
        [InlineData(0, 50)]
        [InlineData(-1, 49)]
        [InlineData(-1, 50)]
        public void NeverIncreaseQualityAbove50(int sellIn, int quality)
        {
            var item = new Item
            {
                Quality = quality,
                SellIn = sellIn
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(50);
        }
    }
}
