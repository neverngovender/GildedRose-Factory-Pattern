using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Factories
{
    public class AgedBrieFactory : GildedRoseFactory
    {
        private Item Item { get; set; }

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
