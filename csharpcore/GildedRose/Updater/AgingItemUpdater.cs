namespace GildedRoseKata.Updater
{
    public class AgingItemUpdater : AbstractItemUpdater
    {
        public override Item UpdateItem(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = CheckQuality(item.Quality + 1);
            }
            else
            {
                item.Quality = CheckQuality(item.Quality + 2);
            }

            item.SellIn--;

            return item;
        }
    }
}
