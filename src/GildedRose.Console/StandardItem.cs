namespace GildedRose.Console
{
    public class StandardItem : AlterableItem
    {
        public StandardItem(string name, int daysToSell, int quality)
            : base(name, daysToSell, quality)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (SellIn > 0)
                return -1;
            return -2;
        }
    }
}
