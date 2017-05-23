using GildedRose.Console;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramTests : TestsUsingStoreItems
    {
        private int _expectedSellIn;
        private Program _program;

        [SetUp]
        public new void SetUp()
        {
            _expectedSellIn = Item.SellIn - 1;
            _program = new Program { Items = new List<Item> { Item } };
        }

        [Test]
        public void UpdateQuality_GivenAgedBrie_ReducesSellInBy1AndIncreasesQualityByNormalRate()
        {
            GivenAgedBrieOfQualityAtMost(MAXIMUM_ITEM_QUALITY - ITEM_QUALITY_CHANGE_RATE);
            var expectedQuality = Item.Quality + ITEM_QUALITY_CHANGE_RATE;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieOfMaximumQuality_ReducesSellInBy1AndIgnoresQuality()
        {
            GivenAgedBrieOfMaximumQuality();
            var expectedQuality = Item.Quality;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieWithNegativeSellIn_ReducesSellInBy1AndIncreasesQualityTwiceAsFast()
        {
            GivenAgedBrieOfQualityAtMostWithNegativeSellIn(MAXIMUM_ITEM_QUALITY - (ITEM_QUALITY_CHANGE_RATE * 2));
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + (ITEM_QUALITY_CHANGE_RATE * 2);

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassOfMaximumQuality_ReducesSellInBy1AndIgnoresQuality()
        {
            GivenBackstagePassOfMaximumQuality();
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = MAXIMUM_ITEM_QUALITY;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellIn0_ReducesSellInBy1AndQualityTo0()
        {
            GivenBackstagePassWithinSellInRange(0, 0);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = 0;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellInBetween10And6_ReducesSellInBy1AndIncreasesQualityBy2()
        {
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - (ITEM_QUALITY_CHANGE_RATE * 3),
                1, IMMINENT_DEADLINE_MARK);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + (ITEM_QUALITY_CHANGE_RATE * 3);

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellInGreaterThan10_ReducesSellInBy1AndIncreasesQualityBy1()
        {
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - ITEM_QUALITY_CHANGE_RATE,
                APPROACHING_DEADLINE_MARK + 1, int.MaxValue);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + ITEM_QUALITY_CHANGE_RATE;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellInLessThan6_ReducesSellInBy1AndIncreasesQualityBy3()
        {
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - (ITEM_QUALITY_CHANGE_RATE * 2),
                IMMINENT_DEADLINE_MARK + 1, APPROACHING_DEADLINE_MARK);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + (ITEM_QUALITY_CHANGE_RATE * 2);

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithNegativeSellIn_ReducesSellInBy1AndQualityTwiceAsFast()
        {
            GivenItemOfQualityAtLeastWithNegativeSellIn(MINIMUM_ITEM_QUALITY + (ITEM_QUALITY_CHANGE_RATE * 2));
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality - (ITEM_QUALITY_CHANGE_RATE * 2);

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithQualityGreaterThanMinimumQuality_ReducesSellInAndQualityByNormalRate()
        {
            GivenItemOfQualityAtLeast(MINIMUM_ITEM_QUALITY + ITEM_QUALITY_CHANGE_RATE);
            var expectedQuality = Item.Quality - ITEM_QUALITY_CHANGE_RATE;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemOfMinimumQuality_ReducesSellInValueAndIgnoresQuality()
        {
            GivenItemOfQuality(MINIMUM_ITEM_QUALITY);
            var expectedQuality = Item.Quality;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenSulfuras_DoesNotChangeItem()
        {
            GivenSulfuras();
            _expectedSellIn = Item.SellIn;
            var expectedQuality = Item.Quality;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        private void GivenAgedBrieOfQualityAtMost(int highestQuality)
        {
            GivenAgedBrie();
            GivenItemOfQualityAtMost(highestQuality);
        }

        private void GivenAgedBrieOfQualityAtMostWithNegativeSellIn(int highestQuality)
        {
            GivenAgedBrie();
            GivenItemOfQualityAtMost(highestQuality);
            GivenItemWithNegativeSellIn();
        }

        private void GivenAgedBrieOfMaximumQuality()
        {
            GivenAgedBrie();
            GivenItemOfQuality(MAXIMUM_ITEM_QUALITY);
        }

        private void GivenBackstagePassWithinSellInRange(int lower, int upper)
        {
            GivenBackstagePass();
            GivenItemWithinSellInRange(lower, upper);
        }

        private void GivenBackstagePassOfQualityAtMostWithinSellInRange(int highestQuality,
            int lowerSellIn, int upperSellIn)
        {
            GivenBackstagePass();
            GivenItemOfQualityAtMost(highestQuality);
            GivenItemWithinSellInRange(lowerSellIn, upperSellIn);
        }

        private void GivenBackstagePassOfMaximumQuality()
        {
            GivenBackstagePass();
            GivenItemOfQuality(MAXIMUM_ITEM_QUALITY);
        }
    }
}
