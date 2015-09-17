using System;

namespace GildedRose.Console
{
    public class ConjuredItem : BaseItem, IItem
    {
        public ConjuredItem(Item wrappedItem) : base(wrappedItem)
        {
        }

        public ConjuredItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public new void UpdateQuality()
        {
            Quality = Math.Max(0, Quality - 2);
        }
    }
}
