﻿using System.Collections.Generic;

namespace GildedRose.Console
{
    public class Program
    {
        private IList<Item> _items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                _items = new List<Item>
                {
                    new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                    new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                    new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                    new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                    new Item
                    {
                        Name = "Backstage passes to a TAFKAL80ETC concert",
                        SellIn = 15,
                        Quality = 20
                    },
                    new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                }
            };

            app.UpdateQuality();

            System.Console.ReadKey();
        }

        public void UpdateQuality()
        {
            // UpdateQuality(_items);
            Update(_items);
        }

        public void Update(IList<Item> items)
        {
            foreach (Item item in items)
            {
                var updater = CreateUpdater(item);
                updater.UpdateQuality();
                updater.UpdateSellIn();
            }
        }

        private IUpdater CreateUpdater(Item item)
        {
            if (item.Name == "Aged Brie")
                return new AgedBrieUpdater(item);
            if (item.Name == "Sulfuras, Hand of Ragnaros")
                return new LegendaryItemUpdater(item);
            if (item.Name.StartsWith("Backstage passes"))
                return new BackstagePassUpdater(item);
            return new StandardItemUpdater(item);
        }

        /*
        public void UpdateQuality(IList<Item> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (items[i].Name != "Aged Brie" && items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    // Decrement quality if it's positive
                    if (items[i].Quality > 0)
                    {
                        if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            items[i].Quality = items[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    // Increment brie and passes quality
                    if (items[i].Quality < 50)
                    {
                        items[i].Quality = items[i].Quality + 1;

                        if (items[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            // Double increment passes quality if close enough
                            if (items[i].SellIn < 11)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }

                            // Triple increment passes quality if close enough
                            if (items[i].SellIn < 6)
                            {
                                if (items[i].Quality < 50)
                                {
                                    items[i].Quality = items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    // Decrement SellIn
                    items[i].SellIn = items[i].SellIn - 1;
                }

                if (items[i].SellIn < 0)
                {
                    if (items[i].Name != "Aged Brie")
                    {
                        if (items[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (items[i].Quality > 0)
                            {
                                // Double decrement quality
                                if (items[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    items[i].Quality = items[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            // Drop passes quality to 0
                            items[i].Quality = items[i].Quality - items[i].Quality;
                        }
                    }
                    else
                    {
                        if (items[i].Quality < 50)
                        {
                            items[i].Quality = items[i].Quality + 1;
                        }
                    }
                }
            }
        }*/
    }
}
