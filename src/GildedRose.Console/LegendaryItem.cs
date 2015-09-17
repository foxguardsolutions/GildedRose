namespace GildedRose.Console
{
    public class LegendaryItem : BaseItem, IItem
    {
        public new int SellIn
        {
            get { return 0; }
            set { InternalItem.SellIn = 0; }
        }

        public LegendaryItem(Item wrappedItem) : base(wrappedItem)
        {
        }

        public LegendaryItem(string name, int sellIn, int quality) : base(name, sellIn, quality)
        {
        }

        public new void UpdateQuality()
        {
        }

        public new void UpdateSellIn()
        {
        }
    }
}
