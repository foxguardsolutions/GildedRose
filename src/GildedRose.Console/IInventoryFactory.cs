using System.Collections.Generic;

namespace GildedRose.Console
{
    public interface IInventoryFactory
    {
        IEnumerable<Item> CreateDefaultItems();
    }
}
