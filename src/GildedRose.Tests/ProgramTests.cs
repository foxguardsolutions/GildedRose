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
        public void UpdateQuality_GivenAgedBrie_ReducesSellInBy1AndIncreasesQualityBy1()
        {
            GivenAgedBrieOfQualityAtMost(MAXIMUM_ITEM_QUALITY - 1);
            var expectedQuality = Item.Quality + 1;

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
        public void UpdateQuality_GivenAgedBrieWithNegativeSellIn_ReducesSellInBy1AndIncreasesQualityBy2()
        {
            GivenAgedBrieOfQualityAtMostWithNegativeSellIn(MAXIMUM_ITEM_QUALITY - 2);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + 2;

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
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 2, 6, 10);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + 2;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellInGreaterThan10_ReducesSellInBy1AndIncreasesQualityBy1()
        {
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 1, 11, int.MaxValue);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + 1;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassWithSellInLessThan6_ReducesSellInBy1AndIncreasesQualityBy3()
        {
            GivenBackstagePassOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 3, 1, 5);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality + 3;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithNegativeSellIn_ReducesSellInBy1AndQualityBy2()
        {
            GivenItemOfQualityAtLeastWithNegativeSellIn(MINIMUM_ITEM_QUALITY + 2);
            _expectedSellIn = Item.SellIn - 1;
            var expectedQuality = Item.Quality - 2;

            _program.UpdateQuality();

            Assert.That(Item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(Item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithQualityGreaterThanMinimumQuality_ReducesSellInAndQualityBy1()
        {
            GivenItemOfQualityAtLeast(MINIMUM_ITEM_QUALITY + 1);
            var expectedQuality = Item.Quality - 1;

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
