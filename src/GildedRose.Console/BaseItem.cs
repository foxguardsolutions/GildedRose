using System;

namespace GildedRose.Console
{
    public class BaseItem : IItem
    {
        public Item InternalItem { get; set; }

        public string Name
        {
            get { return InternalItem.Name; }
            set { InternalItem.Name = value; }
        }

        public int SellIn
        {
            get { return InternalItem.SellIn; }
            set { InternalItem.SellIn = value; }
        }

        public int Quality
        {
            get { return InternalItem.Quality; }
            set { InternalItem.Quality = value; }
        }

        public BaseItem(Item wrappedItem)
        {
            InternalItem = wrappedItem;
        }

        public BaseItem(string name, int sellIn, int quality)
        {
            InternalItem = new Item();
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public void UpdateQuality()
        {
            int modifier = (SellIn < 0) ? 2 : 1;
            Quality = Math.Max(0, Quality - modifier);
        }

        public void UpdateSellIn()
        {
            SellIn -= 1;
        }
    }
}
