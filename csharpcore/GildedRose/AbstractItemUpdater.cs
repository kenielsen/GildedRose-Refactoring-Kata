namespace GildedRoseKata.Updater
{
    public abstract class AbstractItemUpdater
    {
        protected int _max_quality = 50;
        protected int _min_quality = 0;
        public abstract Item UpdateItem(Item item);

        protected int CheckQuality(int quality)
        {
            if (quality > _max_quality)
            {
                return _max_quality;
            }

            if (quality < _min_quality)
            {
                return _min_quality;
            }

            return quality;
        }
    }
}
