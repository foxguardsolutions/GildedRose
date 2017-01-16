using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemFactoryTests : BaseTests
    {
        private ItemFactory _itemFactory;

        [SetUp]
        public void SetUp()
        {
            _itemFactory = new ItemFactory();
        }

        [Test]
        public void Create_GivenLegendaryItemName_ReturnsUnalterableItem()
        {
            var item = _itemFactory.Create("Sulfuras, Hand of Ragnaros", Fixture.Create<int>(), Fixture.Create<int>());

            Assert.That(item, Is.TypeOf(typeof(UnalterableItem)));
        }

        [Test]
        public void Create_GivenNonLegendaryItemName_ReturnsUnalterableItem()
        {
            var item = _itemFactory.Create(Fixture.Create<string>(), Fixture.Create<int>(), Fixture.Create<int>());

            Assert.That(item, Is.TypeOf(typeof(AlterableItem)));
        }
    }
}
