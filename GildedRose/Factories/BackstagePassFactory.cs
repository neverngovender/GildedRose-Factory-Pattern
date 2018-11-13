namespace GildedRose.Factories
{
    public class BackstagePassFactory : GildedRoseFactory
    {
        protected override Item Item { get; }

        public BackstagePassFactory(Item item)
        {
            Item = item;
        }

        public override Item UpdateQuality()
        {
            if (Item.Quality < 50)
                Item.Quality++;

            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
            else if (Item.SellIn <= 5)
            {
                if (Item.Quality < 50)
                    Item.Quality += 2;
            }
            else if (Item.SellIn <= 10)
            {
                if (Item.Quality < 50)
                    Item.Quality++;
            }

            Item.SellIn--;

            return Item;
        }
    }
}
