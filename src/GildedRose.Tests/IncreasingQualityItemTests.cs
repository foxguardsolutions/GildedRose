using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public abstract class IncreasingQualityItemTests : NonLegendaryTests
    {
        [Test]
        public void UpdateQualityOfIncreasingQualityItem_GivenQualityThatCouldIncreaseAboveMaximum_LeavesQualityAtMaximum()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateInRange<int>(Inventory.MAXQUALITY - 1, Inventory.MAXQUALITY);
            var increasingQualityItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };
            var expectedChange = Inventory.MAXQUALITY - quality;

            UpdateInventoryContaining(increasingQualityItem);

            AssertQualityChangedBy(increasingQualityItem, Items[0], expectedChange);
        }
    }
}
