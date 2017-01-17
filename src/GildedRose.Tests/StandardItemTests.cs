using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class StandardItemTests : AlterableItemTests
    {
        [SetUp]
        public void SetUp()
        {
            AlterableItem = Fixture.Create<StandardItem>();
        }

        [Test]
        public void ChangeStandardItemQuality_GivenPositiveSellIn_DecreasesQualityByOne()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY + 1, QualitySpecification.MAX_QUALITY);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality - 1));
        }

        [Test]
        public void ChangeStandardItemQuality_GivenNonPositiveSellIn_DecreasesQualityByTwo()
        {
            AlterableItem.SellIn = Fixture.CreateNonPositive();
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY + 2, QualitySpecification.MAX_QUALITY);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality - 2));
        }

        [Test]
        public void ChangeStandardItemQuality_GivenQualityThatCouldDecreaseBelowMinimum_LeavesQualityAtMinimum()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY, QualitySpecification.MIN_QUALITY + 1);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(QualitySpecification.MIN_QUALITY));
        }
    }
}
