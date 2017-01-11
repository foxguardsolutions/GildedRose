using System;

namespace GildedRose.Console
{
    public class BackstagePassUpdater : IUpdater
    {
        private Item _item;

        public BackstagePassUpdater(Item item)
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
            if (_item.SellIn > 10)
                return 1;
            if (_item.SellIn > 5)
                return 2;
            if (_item.SellIn > 0)
                return 3;
            return -_item.Quality;
        }

        private int VerifyInRange(int newQuality)
        {
            return Math.Min(newQuality, Inventory.MAXQUALITY);
        }
    }
}
