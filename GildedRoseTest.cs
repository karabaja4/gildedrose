using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void Sell_by_date_passed_Quality_degrades_twice_as_fast()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 4 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(2, items[0].Quality);
        }

        [Fact]
        public void Quality_is_never_negative()
        {
            var items = new List<Item> { new Item { Name = "+5 Dexterity Vest", SellIn = 4, Quality = 0 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void Aged_Brie_increases_quality()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 4, Quality = 5 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(6, items[0].Quality);
        }

        [Fact]
        public void Quality_of_an_item_is_never_more_than_50()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 7, Quality = 50 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void Sulfuras_is_legendary_and_Quality_is_always_80()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 2, Quality = 80 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_increases_Quality_by_2_if_10_days_left()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 9 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_increases_Quality_by_3_if_5_days_left()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 9 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void BackstagePass_drops_Quality_to_0_if_sellIn_is_0()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 9 } };
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.Equal(0, items[0].Quality);
        }

        //TODO:
        [Fact]
        public void ConjuredItems_Quality_degrades_twice_as_fast()
        {
           
        }
    }
}