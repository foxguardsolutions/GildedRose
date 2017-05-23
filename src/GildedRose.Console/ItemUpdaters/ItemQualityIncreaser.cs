using System;

namespace GildedRose.Console.ItemUpdaters
{
    public abstract class ItemQualityIncreaser : EndOfDayItemUpdater
    {
        public override void UpdateItemQuality(Item item)
        {
            var qualityChange = GetQualityChange(item);
            item.Quality = Math.Min(item.Quality + qualityChange, MAXIMUM_ITEM_QUALITY);
        }
    }
}
