using GildedRoseKata;
using GildedRoseKata.Updater;
using Shouldly;
using Xunit;

namespace GildedRoseTests.Updater
{
    public class TimeSensitiveItemUpdaterShould
    {
        private readonly TimeSensitiveItemUpdater _updater;

        public TimeSensitiveItemUpdaterShould()
        {
            _updater = new TimeSensitiveItemUpdater();
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
        public void IncreaseQualityBy1WhenSellInGreaterThan10()
        {
            var item = new Item
            {
                SellIn = 11,
                Quality = 0
            };

            item = _updater.UpdateItem(item);
            item.Quality.ShouldBe(1);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void IncreaseQualityBy2WhenSellInGreaterThan5AndLessThanOrEqualTo10(int sellIn)
        {
            var item = new Item
            {
                SellIn = sellIn,
                Quality = 0
            };

            item = _updater.UpdateItem(item);
            item.Quality.ShouldBe(2);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void IncreaseQualityBy2WhenSellInGreaterThanZeroAndLessThanOrEqualToFive(int sellIn)
        {
            var item = new Item
            {
                SellIn = sellIn,
                Quality = 0
            };

            item = _updater.UpdateItem(item);
            item.Quality.ShouldBe(3);
        }

        [Fact]
        public void SetQualityToZeroWhenSellInIsZero()
        {
            var item = new Item
            {
                Quality = 50,
                SellIn = 0
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(0);
        }

        [Fact]
        public void SetQualityToZeroWhenSellInLessThanZero()
        {
            var item = new Item
            {
                Quality = 50,
                SellIn = -1
            };

            item = _updater.UpdateItem(item);

            item.Quality.ShouldBe(0);
        }
    }
}
