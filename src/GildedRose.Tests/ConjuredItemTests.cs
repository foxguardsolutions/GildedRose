using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemTests : NonLegendaryTests
    {
        [SetUp]
        public new void SetName()
        {
            Name = Fixture.Create("Conjured");
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenPositiveSellIn_DecreasesQualityByTwo()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY + 2, Inventory.MAXQUALITY);
            var conjuredItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = -2;

            UpdateInventoryContaining(conjuredItem);

            AssertQualityChangedBy(conjuredItem, Items[0], expectedChange);
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenNonPositiveSellIn_DecreasesQualityByFour()
        {
            var sellIn = Fixture.CreateNonPositive();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY + 4, Inventory.MAXQUALITY);
            var conjuredItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = -4;

            UpdateInventoryContaining(conjuredItem);

            AssertQualityChangedBy(conjuredItem, Items[0], expectedChange);
        }

        [Test]
        public void UpdateConjuredItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY, Inventory.MINQUALITY + 2);
            var conjuredItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = Inventory.MINQUALITY - quality;

            UpdateInventoryContaining(conjuredItem);

            AssertQualityChangedBy(conjuredItem, Items[0], expectedChange);
        }
    }
}
