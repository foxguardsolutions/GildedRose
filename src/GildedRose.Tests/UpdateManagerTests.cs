using System;
using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public class UpdateManagerTests : BaseTests
    {
        private UpdateManager _updateManager;

        [SetUp]
        public void SetUp()
        {
            _updateManager = new UpdateManager();
        }

        [Test]
        public void FilterAlterable_AfterAddingAnUnalterableItem_DoesNotReturnTheUnalterableItem()
        {
            var unalterableItem = Fixture.Build<Item>().With(i => i.Name, "Sulfuras, Hand of Ragnaros").Create();
            Inventory.AddItem(unalterableItem.Name, unalterableItem.SellIn, unalterableItem.Quality);
            var expectedFinalMatchingItemCount = 0;

            var filteredItems = _updateManager.FilterAlterable(Inventory.Items);
            var finalMatchingItemCount = CountItemsMatching(filteredItems, unalterableItem);

            Assert.That(finalMatchingItemCount, Is.EqualTo(expectedFinalMatchingItemCount));
        }

        [Test]
        public void CreateUpdaterFor_GivenItemWithoutSpecialName_ReturnsStandardItemUpdater()
        {
            var updater = _updateManager.CreateUpdaterFor(Item);

            Assert.That(updater, Is.TypeOf(typeof(StandardItemUpdater)));
        }

        [TestCaseSource(nameof(UpdaterTestCases))]
        public void CreateUpdaterFor_GivenSpecialItemName_ReturnsIUpdaterOfCorrectType(string name, Type expectedUpdaterType)
        {
            Item.Name = name;
            var updater = _updateManager.CreateUpdaterFor(Item);

            Assert.That(updater, Is.TypeOf(expectedUpdaterType));
        }

        private static IEnumerable<TestCaseData> UpdaterTestCases()
        {
            yield return new TestCaseData("Aged Brie", typeof(AgedBrieUpdater));
            yield return new TestCaseData("Backstage passes", typeof(BackstagePassUpdater));
            yield return new TestCaseData("Conjured", typeof(ConjuredItemUpdater));
        }
    }
}
