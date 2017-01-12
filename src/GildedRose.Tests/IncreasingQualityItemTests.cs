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
            Item.Quality = Fixture.CreateInRange<int>(Inventory.MAX_QUALITY - 1, Inventory.MAX_QUALITY);
            var expectedChange = Inventory.MAX_QUALITY - Item.Quality;

            UpdateInventoryContaining(Item);

            AssertQualityChangedBy(Item, Inventory.Items[0], expectedChange);
        }
    }
}
