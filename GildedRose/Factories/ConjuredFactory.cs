using GildedRose.Models;

namespace GildedRose.Factories
{
    public class ConjuredFactory : GildedRoseFactory
    {
        protected override Item Item { get; }

        public ConjuredFactory(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            if (Item.Quality > 0)
                Item.Quality -= 2;

            if (Item.SellIn < 0)
            {
                if (Item.Quality > 0)
                    Item.Quality -= 2;
            }

            if (Item.Quality < 0)
                Item.Quality = 0;

            Item.SellIn--;

            return Item;
        }
    }
}
