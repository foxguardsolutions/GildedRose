using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System.Collections.Generic;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ProgramTests
    {
        private const int MAXIMUM_ITEM_QUALITY = 50;
        private const int MINIMUM_ITEM_QUALITY = 0;
        private int _expectedSellIn;
        private Fixture _fixture;
        private Item _item;
        private Program _program;

        [SetUp]
        public void SetUp()
        {
            var qualityRange = MAXIMUM_ITEM_QUALITY - MINIMUM_ITEM_QUALITY + 1;
            _fixture = new Fixture();
            _item = _fixture.Create<Item>();
            _item.Quality = _item.Quality % qualityRange + MINIMUM_ITEM_QUALITY;
            _expectedSellIn = _item.SellIn - 1;
            _program = new Program { Items = new List<Item> { _item } };
        }

        [Test]
        public void UpdateQuality_GivenAgedBrie_ReducesSellInBy1AndIncreasesQualityBy1()
        {
            GivenAgedBrieOfQualityAtMost(MAXIMUM_ITEM_QUALITY - 1);
            var expectedQuality = _item.Quality + 1;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieOfMaximumQuality_ReducesSellInBy1AndIgnoresQuality()
        {
            GivenAgedBrieOfMaximumQuality();
            var expectedQuality = _item.Quality;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenAgedBrieWithNegativeSellIn_ReducesSellInBy1AndIncreasesQualityBy2()
        {
            GivenAgedBrieOfQualityAtMostWithNegativeSellIn(MAXIMUM_ITEM_QUALITY - 2);
            var expectedQuality = _item.Quality + 2;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassesOfMaximumQuality_ReducesSellInBy1AndIgnoresQuality()
        {
            GivenBackstagePassesOfMaximumQuality();
            var expectedQuality = MAXIMUM_ITEM_QUALITY;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassesWithSellIn0_ReducesSellInBy1AndQualityTo0()
        {
            GivenBackstagePassesWithinSellInRange(0, 0);
            var expectedQuality = 0;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassesWithSellInBetween10And6_ReducesSellInBy1AndIncreasesQualityBy2()
        {
            GivenBackstagePassesOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 2, 6, 10);
            var expectedQuality = _item.Quality + 2;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassesWithSellInGreaterThan10_ReducesSellInBy1AndIncreasesQualityBy1()
        {
            GivenBackstagePassesOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 1, 11, int.MaxValue);
            var expectedQuality = _item.Quality + 1;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenBackstagePassesWithSellInLessThan6_ReducesSellInBy1AndIncreasesQualityBy3()
        {
            GivenBackstagePassesOfQualityAtMostWithinSellInRange(MAXIMUM_ITEM_QUALITY - 3, 1, 5);
            var expectedQuality = _item.Quality + 3;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithNegativeSellIn_ReducesSellInBy1AndQualityBy2()
        {
            GivenItemOfQualityAtLeastWithNegativeSellIn(MINIMUM_ITEM_QUALITY + 2);
            var expectedQuality = _item.Quality - 2;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemWithQualityGreaterThanMinimumQuality_ReducesSellInAndQualityBy1()
        {
            GivenItemOfQualityAtLeast(MINIMUM_ITEM_QUALITY + 1);
            var expectedQuality = _item.Quality - 1;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenItemOfMinimumQuality_ReducesSellInValueAndIgnoresQuality()
        {
            GivenItemOfQuality(MINIMUM_ITEM_QUALITY);
            var expectedQuality = _item.Quality;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        [Test]
        public void UpdateQuality_GivenSulfuras_DoesNotChangeItem()
        {
            GivenSulfuras();
            _expectedSellIn = _item.SellIn;
            var expectedQuality = _item.Quality;

            _program.UpdateQuality();

            Assert.That(_item.SellIn, Is.EqualTo(_expectedSellIn));
            Assert.That(_item.Quality, Is.EqualTo(expectedQuality));
        }

        private void GivenAgedBrie()
        {
            _item.Name = "Aged Brie";
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

        private void GivenBackstagePasses()
        {
            _item.Name = "Backstage passes to a TAFKAL80ETC concert";
        }

        private void GivenBackstagePassesWithinSellInRange(int lower, int upper)
        {
            GivenBackstagePasses();
            GivenItemWithinSellInRange(lower, upper);
        }

        private void GivenBackstagePassesOfQualityAtMostWithinSellInRange(int highestQuality,
            int lowerSellIn, int upperSellIn)
        {
            GivenBackstagePasses();
            GivenItemOfQualityAtMost(highestQuality);
            GivenItemWithinSellInRange(lowerSellIn, upperSellIn);
        }

        private void GivenBackstagePassesOfMaximumQuality()
        {
            GivenBackstagePasses();
            GivenItemOfQuality(MAXIMUM_ITEM_QUALITY);
        }

        private void GivenItemOfQualityAtLeast(int lowestQuality)
        {
            while (_item.Quality < lowestQuality)
                _item.Quality++;
        }

        private void GivenItemOfQualityAtLeastWithNegativeSellIn(int lowestQuality)
        {
            GivenItemOfQualityAtLeast(lowestQuality);
            GivenItemWithNegativeSellIn();
        }

        private void GivenItemOfQualityAtMost(int highestQuality)
        {
            while (_item.Quality > highestQuality)
                _item.Quality--;
        }

        private void GivenItemOfQuality(int quality)
        {
            _item.Quality = quality;
        }

        private void GivenItemWithinSellInRange(int lower, int upper)
        {
            var rangeLength = upper - lower + 1;
            _item.SellIn = _item.SellIn % rangeLength + lower;
            _expectedSellIn = _item.SellIn - 1;
        }

        private void GivenItemWithNegativeSellIn()
        {
            _item.SellIn = (-_item.SellIn);
            _expectedSellIn = _item.SellIn - 1;
        }

        private void GivenSulfuras()
        {
            _item.Name = "Sulfuras, Hand of Ragnaros";
            _item.SellIn = 0;
            _item.Quality = 80;
        }
    }
}
