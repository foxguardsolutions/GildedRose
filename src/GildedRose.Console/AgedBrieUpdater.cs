namespace GildedRose.Console
{
    public class AgedBrieUpdater : Updater
    {
        public AgedBrieUpdater(Item item)
            : base(item)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (Item.SellIn > 0)
                return 1;
            return 2;
        }
    }
}
