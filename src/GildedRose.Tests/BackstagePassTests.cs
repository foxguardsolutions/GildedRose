using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackstagePassTests : BaseTests
    {
        [Test]
        public void UpdateQuality_GivenSellByDateElevenOrMoreDaysInTheFutureAndQualityLessThanFifty_IncreasesQualityByOne()
        {
            var sellIn = Fixture.CreateBetween<int>(11, 255);
            var quality = Fixture.CreateBetween<int>(0, 49);
            var passes = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };

            UpdateInventoryContaining(passes);

            AssertSellInDroppedOneQualityIncreasedOne(passes, Items[0]);
        }

        private void AssertSellInDroppedOneQualityIncreasedOne(Item originalItem, Item updatedItem)
        {
            AssertNameDidNotChange(originalItem, updatedItem);
            AssertSellInChangedBy(originalItem, updatedItem, -1);
            AssertQualityChangedBy(originalItem, updatedItem, 1);
        }
    }
}
