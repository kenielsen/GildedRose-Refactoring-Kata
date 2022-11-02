namespace GildedRoseKata.Updater
{
    public class ConjuredItemUpdater : AbstractItemUpdater
    {
        public override Item UpdateItem(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = CheckQuality(item.Quality - 2);
            }
            else
            {
                item.Quality = CheckQuality(item.Quality - 4);
            }

            item.SellIn--;

            return item;
        }
    }
}
