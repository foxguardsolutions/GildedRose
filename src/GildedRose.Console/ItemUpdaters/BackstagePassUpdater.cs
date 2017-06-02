namespace GildedRose.Console.ItemUpdaters
{
    public class BackstagePassUpdater : ItemQualityIncreaser
    {
        internal const int APPROACHING_DEADLINE_MARK = 10;
        internal const int IMMINENT_DEADLINE_MARK = 5;

        public override ItemCategory Category => ItemCategory.BackstagePass;

        public override void UpdateItemQuality(Item item)
        {
            if (IsItemPastDue(item))
                item.Quality = 0;
            else
                base.UpdateItemQuality(item);
        }

        protected override int GetQualityChange(Item item)
        {
            return IsItemSellByImminent(item) ? ItemQualityChangeRate * 3
                 : IsItemSellByApproaching(item) ? ItemQualityChangeRate * 2
                 : ItemQualityChangeRate;
        }

        private bool IsItemSellByApproaching(Item item) => item.SellIn < APPROACHING_DEADLINE_MARK;

        private bool IsItemSellByImminent(Item item) => item.SellIn < IMMINENT_DEADLINE_MARK;
    }
}
