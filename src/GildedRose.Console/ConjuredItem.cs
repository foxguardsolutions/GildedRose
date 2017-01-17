namespace GildedRose.Console
{
    public class ConjuredItem : AlterableItem
    {
        public ConjuredItem(string name, int daysToSell, int quality)
            : base(name, daysToSell, quality)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (SellIn > 0)
                return -2;
            return -4;
        }
    }
}
