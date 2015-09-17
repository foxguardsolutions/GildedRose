using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GildedRose.Console
{
    public class Program
    {
        public IList<Item> Items;

        private Dictionary<string, Type> ItemMapping = new Dictionary<string, Type>()
        {
            {"+5 Dexterity Vest", typeof (BaseItem)},
            {"Aged Brie", typeof (AgedItem)},
            {"Elixir of the Mongoose", typeof (BaseItem)},
            {"Sulfuras, Hand of Ragnaros", typeof (LegendaryItem)},
            {"Backstage passes to a TAFKAL80ETC concert", typeof (TicketItem)},
            {"Conjured Mana Cake", typeof (ConjuredItem)}
        };
             
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
            foreach (var item in Items)
            {
                Type itemType = ItemMapping[item.Name];
                IItem convertedItem = (IItem)Activator.CreateInstance(itemType, item);
                convertedItem.UpdateQuality();
                convertedItem.UpdateSellIn();
            }
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }  
}
