using System;

namespace GildedRose.Console
{
    public class TicketItem : BaseItem, IItem
    {
        public new int Quality
        {
            get
            {
                return InternalItem.Quality;
            }
            set
            {
                InternalItem.Quality = (SellIn < 0) ? 0 : value;
            }
        }

        public TicketItem(Item wrappedItem) : base(wrappedItem)
        {
        }

        public TicketItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public new void UpdateQuality()
        {
            int modifier = (SellIn <= 5) ? 3 : (SellIn <= 10) ? 2 : 1;
            Quality = Math.Min(50, Quality + modifier);
        }
    }
}
