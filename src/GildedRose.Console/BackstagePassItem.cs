namespace GildedRose.Console
{
    public class BackstagePassItem : AlterableItem
    {
        public const int MANY_DAYS = 10;
        public const int FEW_DAYS = 5;
        public const int NO_DAYS = 0;

        public BackstagePassItem(string name, int daysToSell, int quality)
            : base(name, daysToSell, quality)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (SellIn > MANY_DAYS)
                return 1;
            if (SellIn > FEW_DAYS)
                return 2;
            if (SellIn > NO_DAYS)
                return 3;
            return -Quality;
        }
    }
}
