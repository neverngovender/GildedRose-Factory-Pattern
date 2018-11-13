using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose.Factories
{
    public class ElixirOfTheMongooseFactory : GildedRoseFactory
    {
        protected override Item Item { get; }

        public ElixirOfTheMongooseFactory(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            if (Item.Quality > 0)
                Item.Quality--;

            if (Item.SellIn < 0)
            {
                if (Item.Quality > 0)
                    Item.Quality--;
            }

            Item.SellIn--;

            return Item;
        }
    }
}
