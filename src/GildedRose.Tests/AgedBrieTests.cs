using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests : IncreasingQualityItemTests
    {
        [SetUp]
        public void SetName()
        {
            Item.Name = "Aged Brie";
        }

        [Test]
        public void UpdateAgedBrieQuality_GivenPositiveSellIn_IncreasesQualityByOne()
        {
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY, Inventory.MAX_QUALITY - 1);
            var expectedChange = 1;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateAgedBrieQuality_GivenNonPositiveSellIn_IncreasesQualityByTwo()
        {
            Item.SellIn = Fixture.CreateNonPositive();
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY, Inventory.MAX_QUALITY - 2);
            var expectedChange = 2;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }
    }
}
