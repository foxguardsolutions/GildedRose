using System.Collections.Generic;
using NUnit.Framework;
using GildedRose.Console;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestAssemblyTests
    {
        private Program app;

        [SetUp]
        public void Setup()
        {
            app = new Program()
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
        }

        [Test]
        public void TestTheTruth()
        {
            Assert.True(true);
        }

        [TestCase(0, Result = 19)]
        [TestCase(1, Result = 1)]
        [TestCase(2, Result = 6)]
        [TestCase(3, Result = 80)]
        [TestCase(4, Result = 21)]
        [TestCase(5, Result = 4)]
        public int UpdateQualityModifiesQuality(int itemIndex)
        {
            app.UpdateQuality();
            return app.Items[itemIndex].Quality;
        }

        [TestCase(0, Result = 9)]
        [TestCase(1, Result = 1)]
        [TestCase(2, Result = 4)]
        [TestCase(3, Result = 0)]
        [TestCase(4, Result = 14)]
        [TestCase(5, Result = 2)]
        public int UpdateQualityModifiesSellIn(int itemIndex)
        {
            app.UpdateQuality();
            return app.Items[itemIndex].SellIn;
        }
    }
}