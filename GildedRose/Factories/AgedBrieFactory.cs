using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Factories
{
    public class AgedBrieFactory : GildedRoseFactory
    {
        protected override Item Item { get; }

        public AgedBrieFactory(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            if (Item.Quality < 50)
                Item.Quality++;

            if (Item.SellIn < 0)
            {
                if (Item.Quality < 50)
                    Item.Quality++;
            }

            Item.SellIn--;

            return Item;
        }
    }
}
