using System;

namespace GildedRose.Console
{
    public class BackstagePassUpdater : IUpdater
    {
        private Item _item;

        public const int MANYDAYS = 10;
        public const int FEWDAYS = 5;
        public const int NODAYS = 0;

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
            if (_item.SellIn > MANYDAYS)
                return 1;
            if (_item.SellIn > FEWDAYS)
                return 2;
            if (_item.SellIn > NODAYS)
                return 3;
            return -_item.Quality;
        }

        private int VerifyInRange(int newQuality)
        {
            return Math.Min(newQuality, Inventory.MAXQUALITY);
        }
    }
}
