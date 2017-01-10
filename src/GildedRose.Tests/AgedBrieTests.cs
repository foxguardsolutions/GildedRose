using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests : BaseTests
    {
        [Test]
        public void UpdateQuality_GivenSellByDateInTheFutureAndQualityLessThanFifty_IncreasesQualityByOne()
        {
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateBetween<int>(0, 49);
            var brie = new Item { Name = "Aged Brie", SellIn = sellIn, Quality = quality };

            UpdateInventoryContaining(brie);

            AssertSellInDroppedOneQualityIncreasedOne(brie, Items[0]);
        }

        private void AssertSellInDroppedOneQualityIncreasedOne(Item originalItem, Item updatedItem)
        {
            AssertNameDidNotChange(originalItem, updatedItem);
            AssertSellInChangedBy(originalItem, updatedItem, -1);
            AssertQualityChangedBy(originalItem, updatedItem, 1);
        }
    }
}
