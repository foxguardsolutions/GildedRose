namespace GildedRose.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("Press any key to load and update inventory...");
            System.Console.ReadKey();

            var inventory = new Inventory(new ItemFactory(), new UpdaterBuilder());
            var inventoryQualityController = new InventoryQualityController(inventory);
            inventoryQualityController.Start();

            System.Console.WriteLine("Inventory updated successfully!");
            System.Console.ReadKey();
        }
    }
}
