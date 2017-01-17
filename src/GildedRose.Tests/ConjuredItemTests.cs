using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemTests : AlterableItemTests
    {
        [SetUp]
        public void SetName()
        {
            AlterableItem = Fixture.Create<ConjuredItem>();
        }

        [Test]
        public void ChangeConjuredItemQuality_GivenPositiveSellIn_DecreasesQualityByTwo()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY + 2, QualitySpecification.MAX_QUALITY);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality - 2));
        }

        [Test]
        public void ChangeConjuredItemQuality_GivenNonPositiveSellIn_DecreasesQualityByFour()
        {
            AlterableItem.SellIn = Fixture.CreateNonPositive();
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY + 4, QualitySpecification.MAX_QUALITY);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality - 4));
        }

        [Test]
        public void ChangeConjuredItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY, QualitySpecification.MIN_QUALITY + 2);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(QualitySpecification.MIN_QUALITY));
        }
    }
}
