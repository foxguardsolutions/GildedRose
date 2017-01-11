using System;

namespace GildedRose.Console
{
    public class ConjuredItemUpdater : IUpdater
    {
        private Item _item;

        public ConjuredItemUpdater(Item item)
        {
            _item = item;
        }

        public void UpdateSellIn()
        {
            _item.SellIn--;
        }

        public void UpdateQuality()
        {
            var newQuality = _item.Quality - CalculateQualityChange();
            newQuality = VerifyInRange(newQuality);
            _item.Quality = newQuality;
        }

        private int CalculateQualityChange()
        {
            if (_item.SellIn > 0)
                return 2;
            return 4;
        }

        private int VerifyInRange(int newQuality)
        {
            return Math.Max(newQuality, Inventory.MINQUALITY);
        }
    }
}
