using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private static IList<Item> _items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to load and update inventory...");
            System.Console.ReadKey();

            var inventoryFactory = new InventoryFactory(new ItemFactory());
            _items = inventoryFactory.CreateDefaultItems() as IList<Item>;

            var inventoryConditionAdvancer = new InventoryConditionAdvancer(_items);
            inventoryConditionAdvancer.AdvanceAlterableItemProperties();

            System.Console.WriteLine("Inventory updated successfully!");
            System.Console.ReadKey();
        }
    }
}
