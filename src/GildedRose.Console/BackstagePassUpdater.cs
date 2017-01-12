namespace GildedRose.Console
{
    public class BackstagePassUpdater : Updater
    {
        public const int MANY_DAYS = 10;
        public const int FEW_DAYS = 5;
        public const int NO_DAYS = 0;

        public BackstagePassUpdater(Item item)
            : base(item)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (Item.SellIn > MANY_DAYS)
                return 1;
            if (Item.SellIn > FEW_DAYS)
                return 2;
            if (Item.SellIn > NO_DAYS)
                return 3;
            return -Item.Quality;
        }
    }
}
