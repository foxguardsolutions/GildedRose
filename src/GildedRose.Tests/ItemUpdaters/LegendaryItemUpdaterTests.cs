using GildedRose.Console.ItemUpdaters;
using NUnit.Framework;

namespace GildedRose.Tests.ItemUpdaters
{
    [TestFixture]
    public class LegendaryItemUpdaterTests : TestsUsingStoreItems
    {
        private LegendaryItemUpdater _itemUpdater;

        [SetUp]
        public new void SetUp()
        {
            _itemUpdater = new LegendaryItemUpdater();
        }

        [Test]
        public void PassTime_GivenItem_DoesNotChangeItemSellIn()
        {
            var expected = Item.SellIn;

            _itemUpdater.PassTime(Item);

            Assert.That(Item.SellIn, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItem_DoesNotChangeItemQuality()
        {
            var expected = Item.Quality;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }
    }
}
