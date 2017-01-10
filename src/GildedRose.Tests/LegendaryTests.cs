using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class LegendaryTests : BaseTests
    {
        [Test]
        public void UpdateQuality_MakesNoChangeToItem()
        {
            var quality = Fixture.Create<int>();
            var sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = quality };

            UpdateInventoryContaining(sulfuras);

            AssertDidNotChange(sulfuras, Items[0]);
        }

        private void AssertDidNotChange(Item originalItem, Item updatedItem)
        {
            AssertNameDidNotChange(originalItem, updatedItem);
            AssertSellInChangedBy(originalItem, updatedItem, 0);
            AssertQualityChangedBy(originalItem, updatedItem, 0);
        }
    }
}
