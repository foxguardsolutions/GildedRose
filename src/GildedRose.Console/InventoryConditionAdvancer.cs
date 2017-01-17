using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Console
{
    public class InventoryConditionAdvancer
    {
        private IEnumerable<Item> _items;

        public InventoryConditionAdvancer(IEnumerable<Item> items)
        {
            _items = items;
        }

        public void AdvanceAlterableItemProperties()
        {
            foreach (var item in _items.OfType<AlterableItem>())
                AdvanceProperties(item);
        }

        private void AdvanceProperties(AlterableItem item)
        {
            item.ChangeQuality();
            item.AgeItem();
        }
    }
}
