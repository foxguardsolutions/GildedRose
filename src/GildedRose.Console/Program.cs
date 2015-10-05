using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
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
                                          }

            };

            app.UpdateQuality();
            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            List<IItem> updatedItemList = new List<IItem>();

            updatedItemList.Add(new PerishableItem(Items[0].Name, Items[0].Quality, Items[0].SellIn));
            updatedItemList.Add(new AppreciableItem(Items[1].Name, Items[1].Quality, Items[1].SellIn));
            updatedItemList.Add(new PerishableItem(Items[2].Name, Items[2].Quality, Items[2].SellIn));
            updatedItemList.Add(new LegendaryItem(Items[3].Name, Items[3].SellIn));
            updatedItemList.Add(new EquitableItem(Items[4].Name, Items[4].Quality, Items[4].SellIn));
            updatedItemList.Add(new PerishableItem(Items[4].Name, Items[4].Quality, Items[4].SellIn, true));

            foreach (IItem item in updatedItemList)
            {
                item.UpdateAfterDayElapsed();
            }
        }

        public class Item
        {
            public string Name { get; set; }

            public int SellIn { get; set; }

            public int Quality { get; set; }
        }
    }
}
