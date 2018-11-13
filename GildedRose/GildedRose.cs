using GildedRose.Factories;
using GildedRose.Models;

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
            else if (item.Name.Contains("Conjured"))
            {
                factory = new ConjuredFactory(item);
                item = factory.UpdateQuality();
            }

            return item;
        }
    }
}
