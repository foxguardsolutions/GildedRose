using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class NonLegendaryTests : BaseTests
    {
        [Test]
        public void UpdateNonLegendaryItemQuality_DecrementsSellIn()
        {
            UpdateInventoryContaining(Item);

            AssertSellInChangedBy(Item, Inventory.Items[0], -1);
        }

        [Test]
        public void UpdateNonLegendaryItemQuality_DoesNotChangeName()
        {
            UpdateInventoryContaining(Item);

            AssertNameDidNotChange(Item, Inventory.Items[0]);
        }
    }
}
