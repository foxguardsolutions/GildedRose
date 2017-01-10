using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public class BaseTests
    {
        public Fixture Fixture { get; private set; }
        public IList<Item> Items { get; private set; }
        private Program _inventory;

        [SetUp]
        public void BaseSetUp()
        {
            _inventory = new Program();
            Fixture = new Fixture();
        }

        public void UpdateInventoryContaining(Item item)
        {
            PopulateItems(item);
            _inventory.UpdateQuality(Items);
        }

        public void PopulateItems(Item item)
        {
            Items = new List<Item>
            {
                new Item
                {
                    Name = item.Name,
                    SellIn = item.SellIn,
                    Quality = item.Quality
                }
            };
        }

        public void AssertNameDidNotChange(Item originalItem, Item updatedItem)
        {
            Assert.That(updatedItem.Name, Is.EqualTo(originalItem.Name));
        }

        public void AssertSellInChangedBy(Item originalItem, Item updatedItem, int expectedChange)
        {
            var expectedSellIn = originalItem.SellIn + expectedChange;
            Assert.That(updatedItem.SellIn, Is.EqualTo(expectedSellIn));
        }

        public void AssertQualityChangedBy(Item originalItem, Item updatedItem, int expectedChange)
        {
            var expectedQuality = originalItem.Quality + expectedChange;
            Assert.That(updatedItem.Quality, Is.EqualTo(expectedQuality));
        }
    }
}
