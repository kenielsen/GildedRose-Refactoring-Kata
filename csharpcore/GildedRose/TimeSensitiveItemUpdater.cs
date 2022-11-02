namespace GildedRoseKata.Updater
{
    public class TimeSensitiveItemUpdater : AbstractItemUpdater
    {
        public override Item UpdateItem(Item item)
        {
            if (item.SellIn > 10)
            {
                item.Quality = CheckQuality(item.Quality + 1);
            }
            else if (item.SellIn > 5)
            {
                item.Quality = CheckQuality(item.Quality + 2);
            }
            else if (item.SellIn > 0)
            {
                item.Quality = CheckQuality(item.Quality + 3);
            }
            else
            {
                item.Quality = _min_quality;
            }

            item.SellIn--;

            return item;
        }
    }
}
