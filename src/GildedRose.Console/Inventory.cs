using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inventory
    {
        public const int MINQUALITY = 0;
        public const int MAXQUALITY = 50;

        public static void Update(IList<Item> items)
        {
            foreach (Item item in items)
            {
                var updater = CreateUpdater(item);
                updater.UpdateQuality();
                updater.UpdateSellIn();
            }
        }

        private static IUpdater CreateUpdater(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdater(item);
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryItemUpdater(item);
            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassUpdater(item);
            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemUpdater(item);
            return new StandardItemUpdater(item);
        }
    }
}
