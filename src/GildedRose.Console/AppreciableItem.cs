using System;

namespace GildedRose.Console
{
    public class AppreciableItem : IItem
    {
        private const int MAX_QUALITY = 50;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public AppreciableItem(string name, int quality, int sellIn)
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public void UpdateAfterDayElapsed()
        {
            SellIn--;

            UpdateQuality();
        }

        private void UpdateQuality()
        {
            Quality++;
            Quality = Math.Min(Quality, MAX_QUALITY);
        }
    }
}
