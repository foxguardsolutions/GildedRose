using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inventory
    {
        public const int MIN_QUALITY = 0;
        public const int MAX_QUALITY = 50;
        public IList<Item> Items { get; private set; }
        private ItemFactory _itemFactory;
        private UpdateManager _updateManager;

        public Inventory()
            : this(new ItemFactory(), new UpdateManager())
        {
        }

        private Inventory(ItemFactory itemFactory, UpdateManager updateManager)
        {
            _itemFactory = itemFactory;
            _updateManager = updateManager;
            Items = new List<Item>();
        }

        public void AddItem(string name, int daysToSell, int quality)
        {
            var newItem = _itemFactory.Create(name, daysToSell, quality);
            Items.Add(newItem);
        }

        public void AgeAlterableItems()
        {
            var alterableItems = _updateManager.FilterAlterable(Items);
            Age(alterableItems);
        }

        private void Age(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var updater = _updateManager.CreateUpdaterFor(item);
                updater.AgeItem();
            }
        }
    }
}
