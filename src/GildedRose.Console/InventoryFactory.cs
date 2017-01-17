using System.Collections.Generic;

namespace GildedRose.Console
{
    public class InventoryFactory : IInventoryFactory
    {
        private IItemFactory _itemFactory;
        public InventoryFactory(IItemFactory itemFactory)
        {
            _itemFactory = itemFactory;
        }

        public IEnumerable<Item> CreateDefaultItems()
        {
            yield return _itemFactory.CreateStandardItem("+5 Dexterity Vest", 10, 20);
            yield return _itemFactory.CreateAgedBrieItem("Aged Brie", 2, 0);
            yield return _itemFactory.CreateStandardItem("Elixir of the Mongoose", 5, 7);
            yield return _itemFactory.CreateLegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80);
            yield return _itemFactory.CreateBackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            yield return _itemFactory.CreateConjuredItem("Conjured Mana Cake", 3, 6);
        }
    }
}
