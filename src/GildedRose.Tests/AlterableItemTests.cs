using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public abstract class AlterableItemTests : BaseTests
    {
        protected AlterableItem AlterableItem { get; set; }

        [Test]
        public void AgeAlterableItem_DecrementsSellIn()
        {
            var initialSellIn = AlterableItem.SellIn;

            AlterableItem.AgeItem();

            Assert.That(AlterableItem.SellIn, Is.EqualTo(initialSellIn - 1));
        }
    }
}
