using System;

namespace GildedRose.Console.ItemUpdaters
{
    public abstract class ItemQualityDecreaser : EndOfDayItemUpdater
    {
        public override void UpdateItemQuality(Item item)
        {
            var qualityChange = GetQualityChange(item);
            item.Quality = Math.Max(item.Quality - qualityChange, MINIMUM_ITEM_QUALITY);
        }
    }
}
