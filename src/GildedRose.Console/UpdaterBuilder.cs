using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class UpdaterBuilder
    {
        public IEnumerable<Item> FilterAlterable(IEnumerable<Item> items)
        {
            return from item in items
                   where item.GetType() == typeof(AlterableItem)
                   select item;
        }

        public IUpdater CreateUpdaterFor(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdater(item);
            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassUpdater(item);
            if (item.Name.StartsWith("Conjured"))
                return new ConjuredItemUpdater(item);
            return new StandardItemUpdater(item);
        }
    }
}
