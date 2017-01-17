namespace GildedRose.Console
{
    public class AgedBrieItem : AlterableItem
    {
        public AgedBrieItem(string name, int daysToSell, int quality)
            : base(name, daysToSell, quality)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (SellIn > 0)
                return 1;
            return 2;
        }
    }
}
