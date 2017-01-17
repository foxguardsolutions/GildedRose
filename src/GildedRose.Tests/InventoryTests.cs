using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;

namespace GildedRose.Tests
{
    public class InventoryTests : BaseTests
    {
        protected int CountItemsInCollectionMatchingItem(IEnumerable<Item> items, Item item)
        {
            var equivalentItems =
                from i in items
                where (i.Name == item.Name)
                    && (i.Quality == item.Quality)
                    && (i.SellIn == item.SellIn)
                select i;
            return equivalentItems.Count();
        }
    }
}
