using GildedRose.Console.ItemUpdaters;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");
            var app = CreateProgram();
            app.UpdateQuality();
            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            EndOfDayItemUpdater updater;
            
            foreach (var item in Items)
            {
                updater = EndOfDayItemUpdaterFactory.GetItemUpdater(item);
                updater.PassTime(item);
                updater.UpdateItemQuality(item);
            }
        }

        private static Program CreateProgram()
        {
            return new Program() { Items = GetItems() };
        }

        private static IList<Item> GetItems()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }
    }
}
