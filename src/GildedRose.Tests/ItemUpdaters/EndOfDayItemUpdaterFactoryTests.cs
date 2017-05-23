using GildedRose.Console.ItemUpdaters;
using NUnit.Framework;

namespace GildedRose.Tests.ItemUpdaters
{
    [TestFixture]
    public class EndOfDayItemUpdaterFactoryTests : TestsUsingStoreItems
    {
        [Test]
        public void GetItemUpdater_GivenAgedBrie_ReturnsAgedItemUpdater()
        {
            GivenAgedBrie();

            var actual = EndOfDayItemUpdaterFactory.GetItemUpdater(Item);

            Assert.That(actual, Is.TypeOf<AgedItemUpdater>());
        }

        [Test]
        public void GetItemUpdater_GivenBackstagePass_ReturnsBackstagePassUpdater()
        {
            GivenBackstagePass();

            var actual = EndOfDayItemUpdaterFactory.GetItemUpdater(Item);

            Assert.That(actual, Is.TypeOf<BackstagePassUpdater>());
        }

        [Test]
        public void GetItemUpdater_GivenConjuredItem_ReturnsConjuredItemUpdater()
        {
            GivenConjuredItem();

            var actual = EndOfDayItemUpdaterFactory.GetItemUpdater(Item);

            Assert.That(actual, Is.TypeOf<ConjuredItemUpdater>());
        }

        [Test]
        public void GetItemUpdater_GivenItem_ReturnsNormalItemUpdater()
        {
            var actual = EndOfDayItemUpdaterFactory.GetItemUpdater(Item);

            Assert.That(actual, Is.TypeOf<NormalItemUpdater>());
        }

        [Test]
        public void GetItemUpdater_GivenSulfuras_ReturnsLegendaryItemUpdater()
        {
            GivenSulfuras();

            var actual = EndOfDayItemUpdaterFactory.GetItemUpdater(Item);

            Assert.That(actual, Is.TypeOf<LegendaryItemUpdater>());
        }
    }
}
