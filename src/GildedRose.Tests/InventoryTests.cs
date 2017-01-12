using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTests
    {
        [Test]
        public void AddItem_AddsItemToItemsList()
        {
            var item = Fixture.Create<Item>();
            var matchingItemCount = CountItemsMatching(Inventory.Items, item);
            var expectedFinalMatchingItemsCount = matchingItemCount + 1;

            Inventory.AddItem(item.Name, item.SellIn, item.Quality);
            var finalMatchingItemsCount = CountItemsMatching(Inventory.Items, item);

            Assert.That(finalMatchingItemsCount, Is.EqualTo(expectedFinalMatchingItemsCount));
        }
    }
}
