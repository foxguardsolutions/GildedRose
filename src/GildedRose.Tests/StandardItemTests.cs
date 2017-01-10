using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class StandardItemTests : BaseTests
    {
        [Test]
        public void UpdateQuality_GivenSellByDateInFutureAndPositiveQuality_DecreasesQualityByOne()
        {
            var name = Fixture.Create<string>();
            var sellIn = Fixture.Create<int>();
            var quality = Fixture.CreateBetween<int>(1, 50);
            var standardItem = new Item { Name = name, SellIn = sellIn, Quality = quality };

            UpdateInventoryContaining(standardItem);

            AssertSellInDroppedOneQualityDroppedOne(standardItem, Items[0]);
        }

        private void AssertSellInDroppedOneQualityDroppedOne(Item originalItem, Item updatedItem)
        {
            AssertNameDidNotChange(originalItem, updatedItem);
            AssertSellInChangedBy(originalItem, updatedItem, -1);
            AssertQualityChangedBy(originalItem, updatedItem, -1);
        }
    }
}
