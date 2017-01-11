using System;

namespace GildedRose.Console
{
    public class AgedBrieUpdater : IUpdater
    {
        private Item _item;

        public AgedBrieUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateSellIn()
        {
            _item.SellIn--;
        }

        public void UpdateQuality()
        {
            var newQuality = _item.Quality + CalculateQualityChange();
            newQuality = VerifyInRange(newQuality);
            _item.Quality = newQuality;
        }

        private int CalculateQualityChange()
        {
            if (_item.SellIn > 0)
                return 1;
            return 2;
        }

        private int VerifyInRange(int newQuality)
        {
            return Math.Min(newQuality, Inventory.MAXQUALITY);
        }
    }
}
