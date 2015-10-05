using System;

namespace GildedRose.Console
{
    public class EquitableItem : IItem
    {
        private const int MAX_QUALITY = 50;

        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }

        public EquitableItem(string name, int quality, int sellIn)
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
        }

        public void UpdateAfterDayElapsed()
        {
            Quality = (SellIn < 0) ? 0 : (Quality += GrowthRate());
            Quality = Math.Min(Quality, MAX_QUALITY);

            SellIn--;
        }

        private int GrowthRate()
        {
            if (SellIn <= 5)
            {
                return 3;
            }
            else if (SellIn <= 10)
            {
                return 2;
            }

            return 1;
        }
    }
}
