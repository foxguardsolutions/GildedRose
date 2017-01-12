namespace GildedRose.Console
{
    public class Program
    {
        private Inventory _inventory;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                _inventory = new Inventory()
            };

            app.Run();

            System.Console.ReadKey();
        }

        private void Run()
        {
            PopulateItems();
            _inventory.AgeAlterableItems();
        }

        private void PopulateItems()
        {
            _inventory.AddItem("+5 Dexterity Vest", 10, 20);
            _inventory.AddItem("Aged Brie", 2, 0);
            _inventory.AddItem("Elixir of the Mongoose", 5, 7);
            _inventory.AddItem("Sulfuras, Hand of Ragnaros", 0, 80);
            _inventory.AddItem("Backstage passes to a TAFKAL80ETC concert", 15, 20);
            _inventory.AddItem("Conjured Mana Cake", 3, 6);
        }
    }
}
