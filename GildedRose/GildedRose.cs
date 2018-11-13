using System.Collections.Generic;
using GildedRose.Factories;

namespace GildedRose
{
    public class GildedRose
    {
        public static Item CreateGildedRoseFactory(Item item)
        {
            GildedRoseFactory factory;
            if (item.Name.Equals("+5 Dexterity Vest"))
            {
                factory = new DexterityVestFactory(item);
                item = factory.UpdateQuality();
            }
            else if (item.Name.Equals("Aged Brie"))
            {
                factory = new AgedBrieFactory(item);
                item = factory.UpdateQuality();
            }
            else if (item.Name.Equals("Elixir of the Mongoose"))
            {
                factory = new ElixirOfTheMongooseFactory(item);
                item = factory.UpdateQuality();
            }
            else if (item.Name.Contains("Backstage passes"))
            {
                factory = new BackstagePassFactory(item);
                item = factory.UpdateQuality();
            }

            return item;
        }

        public static void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != "Aged Brie")
                    {
                        if (items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].Quality > 0)
                            {
                                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
