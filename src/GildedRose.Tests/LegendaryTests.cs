using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class LegendaryTests : BaseTests
    {
        [Test]
        public void UpdateLegendaryItemQuality_MakesNoChangeToItem()
        {
            Item.Name = "Sulfuras, Hand of Ragnaros";

            UpdateInventoryContaining(Item);

            AssertDidNotChange(Item, Inventory.Items[0]);
        }

        private void AssertDidNotChange(Item originalItem, Item updatedItem)
        {
            AssertNameDidNotChange(originalItem, updatedItem);
            AssertSellInChangedBy(originalItem, updatedItem, 0);
            AssertQualityChangedBy(originalItem, updatedItem, 0);
        }
    }
}
