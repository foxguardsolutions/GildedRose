using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests : IncreasingQualityItemTests
    {
        [SetUp]
        public new void SetName()
        {
            Name = "Aged Brie";
        }

        [Test]
        public void UpdateAgedBrieQuality_GivenPositiveSellIn_IncreasesQualityByOne()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY, Inventory.MAXQUALITY - 1);
            var brie = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = 1;

            UpdateInventoryContaining(brie);

            AssertQualityChangedBy(brie, Items[0], expectedChange);
        }

        [Test]
        public void UpdateAgedBrieQuality_GivenNonPositiveSellIn_IncreasesQualityByTwo()
        {
            var sellIn = Fixture.CreateNonPositive();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY, Inventory.MAXQUALITY - 2);
            var brie = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = 2;

            UpdateInventoryContaining(brie);

            AssertQualityChangedBy(brie, Items[0], expectedChange);
        }
    }
}
