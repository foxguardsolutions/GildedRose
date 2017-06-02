using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class StoreItemIdentifierTests : TestsUsingStoreItems
    {
        [Test]
        public void GetCategory_GivenAgedBrie_ReturnsAged()
        {
            GivenAgedBrie();

            var actual = StoreItemIdentifier.GetCategory(Item);

            Assert.That(actual, Is.EqualTo(ItemCategory.Aged));
        }

        [Test]
        public void GetCategory_GivenBackstagePass_ReturnsBackstagePass()
        {
            GivenBackstagePass();

            var actual = StoreItemIdentifier.GetCategory(Item);

            Assert.That(actual, Is.EqualTo(ItemCategory.BackstagePass));
        }

        [Test]
        public void GetCategory_GivenConjuredItem_ReturnsConjuredItem()
        {
            GivenConjuredItem();

            var actual = StoreItemIdentifier.GetCategory(Item);

            Assert.That(actual, Is.EqualTo(ItemCategory.Conjured));
        }

        [Test]
        public void GetCategory_GivenItem_ReturnsNormal()
        {
            var actual = StoreItemIdentifier.GetCategory(Item);

            Assert.That(actual, Is.EqualTo(ItemCategory.Normal));
        }

        [Test]
        public void GetCategory_GivenSulfuras_ReturnsLegendary()
        {
            GivenSulfuras();

            var actual = StoreItemIdentifier.GetCategory(Item);

            Assert.That(actual, Is.EqualTo(ItemCategory.Legendary));
        }
    }
}
