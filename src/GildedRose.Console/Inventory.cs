using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Inventory
    {
        public const int MIN_QUALITY = 0;
        public const int MAX_QUALITY = 50;
        public IList<Item> Items { get; private set; }
        private ItemFactory _itemFactory;
        private UpdaterBuilder _updaterBuilder;

        public Inventory(ItemFactory itemFactory, UpdaterBuilder updaterBuilder)
        {
            _itemFactory = itemFactory;
            _updaterBuilder = updaterBuilder;
            Items = new List<Item>();
        }

        public void AddItem(string name, int daysToSell, int quality)
        {
            var newItem = _itemFactory.Create(name, daysToSell, quality);
            Items.Add(newItem);
        }

        public void AgeAlterableItems()
        {
            var alterableItems = _updaterBuilder.FilterAlterable(Items);
            Age(alterableItems);
        }

        private void Age(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                var updater = _updaterBuilder.CreateUpdaterFor(item);
                updater.AgeItem();
            }
        }
    }
}
