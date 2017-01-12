namespace GildedRose.Console
{
    public abstract class Updater : IUpdater
    {
        protected Item Item { get; private set; }

        public Updater(Item item)
        {
            Item = item;
        }

        public void AgeItem()
        {
            var changeAmount = CalculateQualityChange();
            ChangeQualityBy(changeAmount);
            DecrementSellIn();
        }

        private void DecrementSellIn()
        {
            Item.SellIn--;
        }

        private void ChangeQualityBy(int changeAmount)
        {
            var newQuality = Item.Quality + changeAmount;
            newQuality = ClampQuality(newQuality);
            Item.Quality = newQuality;
        }

        private int ClampQuality(int quality)
        {
            if (quality < Inventory.MIN_QUALITY)
                return Inventory.MIN_QUALITY;
            if (quality > Inventory.MAX_QUALITY)
                return Inventory.MAX_QUALITY;
            return quality;
        }

        protected abstract int CalculateQualityChange();
    }
}
