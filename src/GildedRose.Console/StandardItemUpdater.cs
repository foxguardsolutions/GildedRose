namespace GildedRose.Console
{
    public class StandardItemUpdater : Updater
    {
        public StandardItemUpdater(Item item)
            : base(item)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (Item.SellIn > 0)
                return -1;
            return -2;
        }
    }
}
