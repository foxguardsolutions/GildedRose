namespace GildedRose.Console
{
    public abstract class AlterableItem : Item
    {
        public AlterableItem(string name, int daysToSell, int quality)
        {
            Name = name;
            SellIn = daysToSell;
            Quality = quality;
        }

        public void ChangeQuality()
        {
            var changeAmount = CalculateQualityChange();
            ChangeQualityBy(changeAmount);
        }

        public void AgeItem()
        {
            SellIn--;
        }

        private void ChangeQualityBy(int changeAmount)
        {
            var newQuality = Quality + changeAmount;
            newQuality = ClampQuality(newQuality);
            Quality = newQuality;
        }

        private int ClampQuality(int quality)
        {
            if (quality < QualitySpecification.MIN_QUALITY)
                return QualitySpecification.MIN_QUALITY;
            if (quality > QualitySpecification.MAX_QUALITY)
                return QualitySpecification.MAX_QUALITY;
            return quality;
        }

        protected abstract int CalculateQualityChange();
    }
}
