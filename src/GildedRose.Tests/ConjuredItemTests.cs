using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemTests : NonLegendaryTests
    {
        [SetUp]
        public void SetName()
        {
            Item.Name = Fixture.Create("Conjured");
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenPositiveSellIn_DecreasesQualityByTwo()
        {
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY + 2, Inventory.MAX_QUALITY);
            var expectedChange = -2;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenNonPositiveSellIn_DecreasesQualityByFour()
        {
            Item.SellIn = Fixture.CreateNonPositive();
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY + 4, Inventory.MAX_QUALITY);
            var expectedChange = -4;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY, Inventory.MIN_QUALITY + 2);
            var expectedChange = Inventory.MIN_QUALITY - Item.Quality;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }
    }
}
