using System.Collections.Generic;
using System.Linq;
using GildedRose.Console;
using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public class InventoryConditionAdvancerTests : InventoryTests
    {
        private IEnumerable<Item> _items;
        private InventoryConditionAdvancer _inventoryConditionAdvancer;

        [SetUp]
        public void SetUp()
        {
            var inventoryFactory = SetUpMockInventoryFactory();
            _items = inventoryFactory.CreateDefaultItems().ToList();
            _inventoryConditionAdvancer = new InventoryConditionAdvancer(_items);
        }

        private IInventoryFactory SetUpMockInventoryFactory()
        {
            var mock = new Mock<IInventoryFactory>();
            mock.Setup(i => i.CreateDefaultItems()).Returns(CreateManyAlterableAndUnalterableItems());
            return mock.Object;
        }

        private IEnumerable<Item> CreateManyAlterableAndUnalterableItems()
        {
            Fixture.Register<AlterableItem>(() => Fixture.Create<StandardItem>());
            Fixture.Register<UnalterableItem>(() => Fixture.Create<LegendaryItem>());

            var alterableItems = Fixture.CreateMany<AlterableItem>() as IEnumerable<Item>;
            var unalterableItems = Fixture.CreateMany<UnalterableItem>();
            return alterableItems.Concat(unalterableItems);
        }

        [Test]
        public void AdvanceAlterableItemProperties_DoesNotChangeUnalterableItemProperties()
        {
            var initialUnalterableItems = _items
                .OfType<UnalterableItem>()
                .Select(i => Clone(i))
                .ToList();
            var initialUnalterableItemCounts = initialUnalterableItems
                .Select(i => CountItemsInCollectionMatchingItem(_items, i));

            _inventoryConditionAdvancer.AdvanceAlterableItemProperties();
            var finalCountsMatchingInitialUnalterableItems = initialUnalterableItems
                .Select(i => CountItemsInCollectionMatchingItem(_items, i));

            Assert.That(finalCountsMatchingInitialUnalterableItems, Is.EqualTo(initialUnalterableItemCounts));
        }

        [Test]
        public void AdvanceAlterableItemProperties_ChangesPropertiesOfAllAlterableItemsInInventory()
        {
            var initialAlterableItems = _items
                .OfType<AlterableItem>()
                .Select(i => Clone(i))
                .ToList();
            var arrayOfAllZeros = new int[initialAlterableItems.Count()];

            _inventoryConditionAdvancer.AdvanceAlterableItemProperties();
            var finalCountsMatchingInitialAlterableItems = initialAlterableItems
                .Select(i => CountItemsInCollectionMatchingItem(_items, i));

            Assert.That(finalCountsMatchingInitialAlterableItems, Is.EquivalentTo(arrayOfAllZeros));
        }

        private Item Clone(Item item)
        {
            return new Item { Name = item.Name, SellIn = item.SellIn, Quality = item.Quality };
        }
    }
}
