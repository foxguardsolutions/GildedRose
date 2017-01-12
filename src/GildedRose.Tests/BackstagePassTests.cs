using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackstagePassTests : IncreasingQualityItemTests
    {
        [SetUp]
        public void SetName()
        {
            Item.Name = Fixture.Create("Backstage passes");
        }

        [TestCase(BackstagePassUpdater.MANY_DAYS + 1, byte.MaxValue, 1)]
        [TestCase(BackstagePassUpdater.FEW_DAYS + 1, BackstagePassUpdater.MANY_DAYS, 2)]
        [TestCase(BackstagePassUpdater.NO_DAYS + 1, BackstagePassUpdater.FEW_DAYS, 3)]
        public void UpdateBackstagePassQuality_GivenSellInWithinRange_IncreasesQualityBy(
            int minDays, int maxDays, int expectedChange)
        {
            Item.SellIn = Fixture.CreateInRange<int>(minDays, maxDays);
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MIN_QUALITY, Inventory.MAX_QUALITY - expectedChange);

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }

        [Test]
        public void UpdateBackstagePassQuality_GivenNonPositiveSellIn_LeavesQualityAtMinimum()
        {
            Item.SellIn = Fixture.CreateNonPositive();
            var expectedChange = Inventory.MIN_QUALITY - Item.Quality;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }
    }
}
