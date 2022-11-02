namespace GildedRoseKata.Updater
{
    public class LegendaryItemUpdater : AbstractItemUpdater
    {
        public override Item UpdateItem(Item item)
        {
            item.Quality = 80;
            return item;
        }
    }
}
