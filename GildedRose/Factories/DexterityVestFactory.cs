﻿namespace GildedRose.Factories
{
    public class DexterityVestFactory : GildedRoseFactory
    {
        private Item Item { get; set; }

        public DexterityVestFactory(Item item)
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