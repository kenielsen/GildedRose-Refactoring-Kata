using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using Shouldly;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Theory]
        [InlineData(1, 0, 0)]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, 1, 0)]
        public void QualityShouldNotBeLessThanZero(int sellIn, int startingQuality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Item Name",
                Quality = startingQuality,
                SellIn = sellIn,
            };

            var app = new GildedRose(new List<Item> { item });

            app.UpdateQuality();

            item.Quality.ShouldBe(expectedQuality);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 2)]
        [InlineData(-1, 0, 2)]
        public void AgedBrieShouldIncreaseInQuality(int sellIn, int startingQuality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = startingQuality,
                SellIn = sellIn,
            };

            var app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();

            item.Quality.ShouldBe(expectedQuality);
        }

        [Theory]
        [InlineData(1, 50, 50)]
        [InlineData(0, 50, 50)]
        [InlineData(0, 49, 50)]
        [InlineData(-1, 50, 50)]
        [InlineData(-1, 49, 50)]
        public void AgedBrieShouldNeverHaveQualityGreaterThan50(int sellIn, int startingQuality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = startingQuality,
                SellIn = sellIn
            };

            var app = new GildedRose(new List<Item>() { item });

            app.UpdateQuality();

            item.Quality.ShouldBe(expectedQuality);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void SulfurasShouldAlwaysHas80Quality(int sellIn)
        {
            var item = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = sellIn,
                Quality = 80
            };

            var app = new GildedRose(new List<Item> { item });
            app.UpdateQuality();

            item.Quality.ShouldBe(80);
            item.SellIn.ShouldBe(sellIn);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void BackstagePassesShouldHaveZeroQualityWhenConcertIsPassed(int sellIn)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = 50
            };

            var app = new GildedRose(new List<Item>() { item });

            app.UpdateQuality();

            item.Quality.ShouldBe(0);
        }

        [Theory]
        [InlineData(12, 0, 1)]
        [InlineData(10, 0, 2)]
        [InlineData(5, 0, 3)]
        public void BackstagePassesShouldIncreaseInQuality(int sellIn, int startingQuality, int expectedQuality)
        {
            var item = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = sellIn,
                Quality = startingQuality
            };

            var app = new GildedRose(new List<Item>() { item });

            app.UpdateQuality();

            item.Quality.ShouldBe(expectedQuality);
        }
    }
}
