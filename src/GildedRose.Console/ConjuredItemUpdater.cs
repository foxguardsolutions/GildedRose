namespace GildedRose.Console
{
    public class ConjuredItemUpdater : Updater
    {
        public ConjuredItemUpdater(Item item)
            : base(item)
        {
        }

        protected override int CalculateQualityChange()
        {
            if (Item.SellIn > 0)
                return -2;
            return -4;
        }
    }
}
