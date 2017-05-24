using System;

namespace GildedRose.Console
{
    public class AgedItem : BaseItem, IItem
    {
        public AgedItem(Item wrappedItem) : base(wrappedItem)
        {
        }

        public AgedItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public new void UpdateQuality()
        {
            int modifier = (SellIn < 0) ? 2 : 1;
            Quality = Math.Min(50, Quality + modifier);
        }
    }
}
