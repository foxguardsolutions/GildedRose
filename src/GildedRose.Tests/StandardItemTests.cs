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
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY + 1, Inventory.MAXQUALITY);
            var standardItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = -1;

            UpdateInventoryContaining(standardItem);

            AssertQualityChangedBy(standardItem, Items[0], expectedChange);
        }

        [Test]
        public void UpdateStandardItemQuality_GivenNonPositiveSellIn_DecreasesQualityByTwo()
        {
            var sellIn = Fixture.CreateNonPositive();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY + 2, Inventory.MAXQUALITY);
            var standardItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = -2;

            UpdateInventoryContaining(standardItem);

            AssertQualityChangedBy(standardItem, Items[0], expectedChange);
        }

        [Test]
        public void UpdateStandardItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY, Inventory.MINQUALITY + 1);
            var standardItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = Inventory.MINQUALITY - quality;

            UpdateInventoryContaining(standardItem);

            AssertQualityChangedBy(standardItem, Items[0], expectedChange);
        }
    }
}
