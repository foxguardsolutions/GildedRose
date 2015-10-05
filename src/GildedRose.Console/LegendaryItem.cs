namespace GildedRose.Console
{
    public class LegendaryItem : IItem
    {
        private const int LEGENDARY_ITEM_QUALITY = 80;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public LegendaryItem(string name,int sellIn)
        {
            Name = name;
            Quality = LEGENDARY_ITEM_QUALITY;
            SellIn = sellIn;
        }

        public void UpdateAfterDayElapsed()
        {
        }
    }
}
