using System.Collections.Generic;
using System.Linq;
using GildedRose.Factories;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTests
    {
        private IList<Item> _items;

        [SetUp]
        public void Init()
        {
            _items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        [Test]
        public void Given_list_of_items_should_have_quality_and_sellin_updated()
        {
            GildedRose.UpdateQuality(_items);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("+5 Dexterity Vest")).Quality == 19 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("+5 Dexterity Vest")).SellIn == 9);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Aged Brie")).Quality == 1 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Aged Brie")).SellIn == 1);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Elixir of the Mongoose")).Quality == 6 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Elixir of the Mongoose")).SellIn == 4);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Sulfuras, Hand of Ragnaros")).Quality == 80 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Sulfuras, Hand of Ragnaros")).SellIn == 0);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert")).Quality == 21 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Backstage passes to a TAFKAL80ETC concert")).SellIn == 14);

            Assert.IsTrue(_items?.FirstOrDefault(x => x.Name.Equals("Conjured Mana Cake")).Quality == 5 &&
                          _items?.FirstOrDefault(x => x.Name.Equals("Conjured Mana Cake")).SellIn == 2);
        }

        [TestCase("+5 Dexterity Vest", 10, 20, 9, 19)]
        [TestCase("Aged Brie", 2, 0, 1, 1)]
        [TestCase("Elixir of the Mongoose", 5, 7, 4, 6)]
        [TestCase("Sulfuras, Hand of Ragnaros", 0, 80, 0, 80)]
        [TestCase("Backstage passes to a TAFKAL80ETC concert", 15, 20, 14, 21)]
        public void GildedRoseFactoryTest(string name, int sellIn, int quality, int expectedSellIn, int expectedQuality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            item = GildedRose.CreateGildedRoseFactory(item);
            Assert.IsTrue(item.Quality == expectedQuality && item.SellIn == expectedSellIn);
        }
    }
}
