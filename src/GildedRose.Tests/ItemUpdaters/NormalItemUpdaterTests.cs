using GildedRose.Console.ItemUpdaters;
using NUnit.Framework;

namespace GildedRose.Tests.ItemUpdaters
{
    [TestFixture]
    public class NormalItemUpdaterTests : TestsUsingStoreItems
    {
        private NormalItemUpdater _itemUpdater;

        [SetUp]
        public new void SetUp()
        {
            _itemUpdater = new NormalItemUpdater();
        }

        [Test]
        public void PassTime_GivenItem_DecreasesItemSellInBy1()
        {
            var expected = Item.SellIn - 1;

            _itemUpdater.PassTime(Item);

            Assert.That(Item.SellIn, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItem_DecreasesItemQualityByNormalRate()
        {
            GivenItemOfQualityAtLeast(MINIMUM_ITEM_QUALITY + ITEM_QUALITY_CHANGE_RATE);
            var expected = Item.Quality - ITEM_QUALITY_CHANGE_RATE;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemOfMinimumQuality_DoesNotChangeItemQuality()
        {
            GivenItemOfQuality(MINIMUM_ITEM_QUALITY);
            var expected = Item.Quality;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemPassedDue_DecreasesItemQualityByTwiceTheNormalRate()
        {
            GivenItemOfQualityAtLeastWithNegativeSellIn(MINIMUM_ITEM_QUALITY + (ITEM_QUALITY_CHANGE_RATE * 2));
            var expected = Item.Quality - (ITEM_QUALITY_CHANGE_RATE * 2);

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }
    }
}
