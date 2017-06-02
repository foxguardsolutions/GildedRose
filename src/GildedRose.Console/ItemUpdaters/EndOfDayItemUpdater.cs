namespace GildedRose.Console.ItemUpdaters
{
    public abstract class EndOfDayItemUpdater
    {
        internal const int MAXIMUM_ITEM_QUALITY = 50;
        internal const int MINIMUM_ITEM_QUALITY = 0;
        internal const int ITEM_QUALITY_CHANGE_RATE = 1;

        public abstract ItemCategory Category { get; }

        protected virtual int ItemQualityChangeRate { get => ITEM_QUALITY_CHANGE_RATE; }
        
        public virtual void PassTime(Item item) => item.SellIn--;

        public abstract void UpdateItemQuality(Item item);

        protected virtual int GetQualityChange(Item item)
        {
            return IsItemPastDue(item) ? ItemQualityChangeRate * 2 : ItemQualityChangeRate;
        }

        protected bool IsItemPastDue(Item item) => item.SellIn < 0;
    }
}
