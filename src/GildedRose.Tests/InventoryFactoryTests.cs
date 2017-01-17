using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class InventoryFactoryTests : InventoryTests
    {
        [Test]
        public void CreateDefaultItems_ReturnsCollectionOfDefaultItems()
        {
            var mockItemFactory = new Mock<IItemFactory>();
            var expectedItems = CreateSixItems().ToList();
            SetUpMockItemFactory(mockItemFactory, expectedItems);

            var inventoryFactory = new InventoryFactory(mockItemFactory.Object);
            var actualItems = inventoryFactory.CreateDefaultItems();

            AssertCollectionsAreEquivalent(actualItems, expectedItems);
        }

        private IEnumerable<Item> CreateSixItems()
        {
            Fixture.RepeatCount = 6;
            return Fixture.CreateMany<Item>();
        }

        private void SetUpMockItemFactory(Mock<IItemFactory> mock, IReadOnlyList<Item> items)
        {
            mock.Setup(i => i.CreateStandardItem("+5 Dexterity Vest", 10, 20))
                .Returns(items[0]);
            mock.Setup(i => i.CreateAgedBrieItem("Aged Brie", 2, 0))
                .Returns(items[1]);
            mock.Setup(i => i.CreateStandardItem("Elixir of the Mongoose", 5, 7))
                .Returns(items[2]);
            mock.Setup(i => i.CreateLegendaryItem("Sulfuras, Hand of Ragnaros", 0, 80))
                .Returns(items[3]);
            mock.Setup(i => i.CreateBackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 15, 20))
                .Returns(items[4]);
            mock.Setup(i => i.CreateConjuredItem("Conjured Mana Cake", 3, 6))
                .Returns(items[5]);
        }

        private void AssertCollectionsAreEquivalent(IEnumerable<Item> actualCollection, IEnumerable<Item> expectedCollection)
        {
            Assert.That(actualCollection.Count(), Is.EqualTo(expectedCollection.Count()));

            foreach (var item in actualCollection)
                AssertEquivalentItemsOccurSameNumberOfTimesInCollections(item, actualCollection, expectedCollection);
        }

        private void AssertEquivalentItemsOccurSameNumberOfTimesInCollections(
            Item item, IEnumerable<Item> actualCollection, IEnumerable<Item> expectedCollection)
        {
            var actualCount = CountItemsInCollectionMatchingItem(actualCollection, item);
            var expectedCount = CountItemsInCollectionMatchingItem(expectedCollection, item);

            Assert.That(actualCount, Is.EqualTo(expectedCount));
        }
    }
}
