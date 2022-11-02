namespace GildedRoseKata.Updater
{
    public class BasicItemUpdater : AbstractItemUpdater
    {
        private readonly bool _increaseQuality;
        public BasicItemUpdater(bool increaseQuality)
        {
            _increaseQuality = increaseQuality;
        }
        public override Item UpdateItem(Item item)
        {
            if (item.SellIn > 0)
            {
                item.Quality = CheckQuality(item.Quality + GetMultiplier() * 1);
            }
            else
            {
                item.Quality = CheckQuality(item.Quality + GetMultiplier() * 2);
            }

            item.SellIn--;

            return item;
        }

        private int GetMultiplier()
        {
            if (_increaseQuality)
            {
                return 1;
            }

            return -1;
        }
    }
}
