using System;

namespace GildedRose.Console
{
    public class BaseItem : IItem
    {
        public Item internalItem { get; set; }

        public string Name
        {
            get { return internalItem.Name; }
            set { internalItem.Name = value; }
        }

        public int SellIn
        {
            get { return internalItem.SellIn; }
            set { internalItem.SellIn = value; }
        }

        public int Quality
        {
            get { return internalItem.Quality; }
            set { internalItem.Quality = value; }
        }

        public BaseItem(Item wrappedItem)
        {
            internalItem = wrappedItem;
        }

        public BaseItem(string name, int sellIn, int quality)
        {
            internalItem = new Item();
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
