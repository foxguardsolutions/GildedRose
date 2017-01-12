using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class StandardItemTests : NonLegendaryTests
    {
        [Test]
        public void UpdateStandardItemQuality_GivenPositiveSellIn_DecreasesQualityByOne()
        {
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY + 1, Inventory.MAX_QUALITY);
            var expectedChange = -1;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateStandardItemQuality_GivenNonPositiveSellIn_DecreasesQualityByTwo()
        {
            Item.SellIn = Fixture.CreateNonPositive();
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY + 2, Inventory.MAX_QUALITY);
            var expectedChange = -2;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateStandardItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY, Inventory.MIN_QUALITY + 1);
            var expectedChange = Inventory.MIN_QUALITY - Item.Quality;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }
    }
}
