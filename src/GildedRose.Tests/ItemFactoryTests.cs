using System;
using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemFactoryTests : BaseTests
    {
        private string _name;
        private int _daysToSell;
        private int _quality;
        private IItemFactory _itemFactory;

        [SetUp]
        public void SetUp()
        {
            _name = Fixture.Create<string>();
            _daysToSell = Fixture.Create<int>();
            _quality = Fixture.Create<int>();
            _itemFactory = new ItemFactory();
        }

        [Test]
        public void CreateAgedBrieItem_GivenInitialPropertyValues_ReturnsAgedBrieItemWithCorrectProperties()
        {
            var brie = _itemFactory.CreateAgedBrieItem(_name, _daysToSell, _quality);

            AssertCorrectItemCreated(brie, typeof(AgedBrieItem));
        }

        [Test]
        public void CreateBackstagePassItem_GivenInitialPropertyValues_ReturnsBackstagePassItemWithCorrectProperties()
        {
            var backstagePass = _itemFactory.CreateBackstagePassItem(_name, _daysToSell, _quality);

            AssertCorrectItemCreated(backstagePass, typeof(BackstagePassItem));
        }

        [Test]
        public void CreateConjuredItem_GivenInitialPropertyValues_ReturnsConjuredItemWithCorrectProperties()
        {
            var conjuredItem = _itemFactory.CreateConjuredItem(_name, _daysToSell, _quality);

            AssertCorrectItemCreated(conjuredItem, typeof(ConjuredItem));
        }

        [Test]
        public void CreateLegendaryItem_GivenInitialPropertyValues_ReturnsLegendaryItemWithCorrectProperties()
        {
            var legendaryItem = _itemFactory.CreateLegendaryItem(_name, _daysToSell, _quality);

            AssertCorrectItemCreated(legendaryItem, typeof(LegendaryItem));
        }

        [Test]
        public void CreateStandardItem_GivenInitialPropertyValues_ReturnsStandardItemWithCorrectProperties()
        {
            var standardItem = _itemFactory.CreateStandardItem(_name, _daysToSell, _quality);

            AssertCorrectItemCreated(standardItem, typeof(StandardItem));
        }

        private void AssertCorrectItemCreated(Item item, Type expectedType)
        {
            Assert.That(item, Is.TypeOf(expectedType));
            AssertItemPropertiesMatchCreateMethodArguments(item);
        }

        private void AssertItemPropertiesMatchCreateMethodArguments(Item item)
        {
            Assert.That(item.Name, Is.EqualTo(_name));
            Assert.That(item.SellIn, Is.EqualTo(_daysToSell));
            Assert.That(item.Quality, Is.EqualTo(_quality));
        }
    }
}
