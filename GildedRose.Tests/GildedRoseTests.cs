using GildedRose.Models;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        [TestCase("+5 Dexterity Vest", 10, 20, 9, 19)]
        [TestCase("Aged Brie", 2, 0, 1, 1)]
        [TestCase("Elixir of the Mongoose", 5, 7, 4, 6)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        [TestCase("Conjured Mana Cake", 3, 6, 2, 4)]
        public void GildedRoseFactoryTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            item = GildedRose.CreateGildedRoseFactory(item);
            Assert.IsTrue(item.Quality == expectedQuality && item.SellIn == expectedSellIn);
        }
    }
}
