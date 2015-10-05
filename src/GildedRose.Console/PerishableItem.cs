using System;

namespace GildedRose.Console
{
    public class PerishableItem : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public bool Conjured { get; set; }

        public PerishableItem(string name, int quality, int sellIn, bool conjured = false)
        {
            Name = name;
            Quality = quality;
            SellIn = sellIn;
            Conjured = conjured;
        }

        public void UpdateAfterDayElapsed()
        {
            SellIn--;

            UpdateQuality();
        }

        private void UpdateQuality()
        {
            if (IsExpired())
            {
                Quality = 0;
            }
            else
            {
                Quality -= GrowthRate();
                Quality = Math.Max(Quality, 0);
            }
        }

        private bool IsExpired()
        {
            return SellIn <= 0;
        }

        private int GrowthRate()
        {
            int growthRate = SellIn < 0 ? 2 : 1;

            growthRate = Conjured ? growthRate * 2 : growthRate;

            return growthRate;
        }
    }
}
