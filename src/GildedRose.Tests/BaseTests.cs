using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public class BaseTests
    {
        protected Fixture Fixture { get; private set; }
        protected Inventory Inventory { get; private set; }
        protected Item Item { get; private set; }

        [SetUp]
        public void BaseSetUp()
        {
            Fixture = new Fixture();
            Inventory = Fixture.Create<Inventory>();
            Item = Fixture.Create<Item>();
        }

        public void UpdateInventoryContaining(Item item)
        {
            Inventory.AddItem(item.Name, item.SellIn, item.Quality);
            Inventory.AgeAlterableItems();
        }

        public void AssertQualityChangedBy(Item originalItem, Item updatedItem, int expectedChange)
        {
            var expectedQuality = originalItem.Quality + expectedChange;
            Assert.That(updatedItem.Quality, Is.EqualTo(expectedQuality));
        }

        public void AssertSellInChangedBy(Item originalItem, Item updatedItem, int expectedChange)
        {
            var expectedSellIn = originalItem.SellIn + expectedChange;
            Assert.That(updatedItem.SellIn, Is.EqualTo(expectedSellIn));
        }

        public void AssertNameDidNotChange(Item originalItem, Item updatedItem)
        {
            Assert.That(updatedItem.Name, Is.EqualTo(originalItem.Name));
        }

        protected int CountItemsMatching(IEnumerable<Item> items, Item item)
        {
            var matchingItems =
                from i in items
                where (i.Name == item.Name)
                    && (i.Quality == item.Quality)
                    && (i.SellIn == item.SellIn)
                select i;
            return matchingItems.Count();
        }
    }
}
