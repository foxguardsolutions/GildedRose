using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackstagePassTests : IncreasingQualityItemTests
    {
        [SetUp]
        public new void SetName()
        {
            Name = Fixture.Create("Backstage passes");
        }

        [TestCase(BackstagePassUpdater.MANYDAYS + 1, byte.MaxValue, 1)]
        [TestCase(BackstagePassUpdater.FEWDAYS + 1, BackstagePassUpdater.MANYDAYS, 2)]
        [TestCase(BackstagePassUpdater.NODAYS + 1, BackstagePassUpdater.FEWDAYS, 3)]
        public void UpdateBackstagePassQuality_GivenSellInWithinRange_IncreasesQualityBy(
            int minDays, int maxDays, int expectedChange)
        {
            var sellIn = Fixture.CreateInRange<int>(minDays, maxDays);
            var quality = Fixture.CreateInRange<int>(Inventory.MINQUALITY, Inventory.MAXQUALITY - expectedChange);
            var passes = new Item { Name = Name, SellIn = sellIn, Quality = quality };

            UpdateInventoryContaining(passes);

            AssertQualityChangedBy(passes, Items[0], expectedChange);
        }

        [Test]
        public void UpdateBackstagePassQuality_GivenNonPositiveSellIn_LeavesQualityAtMinimum()
        {
            var sellIn = Fixture.CreateNonPositive();
            var quality = Fixture.Create<int>();
            var passes = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = Inventory.MINQUALITY - quality;

            UpdateInventoryContaining(passes);

            AssertQualityChangedBy(passes, Items[0], expectedChange);
        }
    }
}
