using GildedRose.Console.ItemUpdaters;
using NUnit.Framework;

namespace GildedRose.Tests.ItemUpdaters
{
    [TestFixture]
    public class BackstagePassUpdaterTests : TestsUsingStoreItems
    {
        private BackstagePassUpdater _itemUpdater;

        [SetUp]
        public new void SetUp()
        {
            _itemUpdater = new BackstagePassUpdater();
        }

        [Test]
        public void PassTime_GivenItem_DecreasesItemSellInBy1()
        {
            var expected = Item.SellIn - 1;

            _itemUpdater.PassTime(Item);

            Assert.That(Item.SellIn, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemAfterSellByDate_ReducesQualityTo0()
        {
            GivenItemWithNegativeSellIn();
            var expected = 0;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemOfMaxQuality_DoesNotChangeQuality()
        {
            GivenItemOfQuality(MAXIMUM_ITEM_QUALITY);
            var expected = Item.Quality;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemWithSellInAfterImminentDeadlineMark_IncreasesQualityByThreeTimesTheNormalRate()
        {
            GivenItemOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - (ITEM_QUALITY_CHANGE_RATE * 3),
                0, IMMINENT_DEADLINE_MARK - 1);
            var expected = Item.Quality + (ITEM_QUALITY_CHANGE_RATE * 3);

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemWithSellInBeforeApproachingDeadlineMark_IncreasesQualityByNormalRate()
        {
            GivenItemOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - ITEM_QUALITY_CHANGE_RATE,
                APPROACHING_DEADLINE_MARK, int.MaxValue);
            var expected = Item.Quality + ITEM_QUALITY_CHANGE_RATE;

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        [Test]
        public void UpdateItemQuality_GivenItemWithSellInBetweenImminentAndApproachingDeadlineMarks_IncreasesQualityTwiceTheNormalRate()
        {
            GivenItemOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - (ITEM_QUALITY_CHANGE_RATE * 2),
                IMMINENT_DEADLINE_MARK, APPROACHING_DEADLINE_MARK - 1);
            var expected = Item.Quality + (ITEM_QUALITY_CHANGE_RATE * 2);

            _itemUpdater.UpdateItemQuality(Item);

            Assert.That(Item.Quality, Is.EqualTo(expected));
        }

        private void GivenItemOfQualityAtMostWithinSellInRange(int highestQuality, int lowerSellIn, int upperSellIn)
        {
            GivenItemOfQualityAtMost(highestQuality);
            GivenItemWithinSellInRange(lowerSellIn, upperSellIn);
        }
    }
}
