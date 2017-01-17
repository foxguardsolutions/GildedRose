using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests : IncreasingQualityItemTests
    {
        [SetUp]
        public void SetName()
        {
            AlterableItem = Fixture.Create<AgedBrieItem>();
        }

        [Test]
        public void ChangeAgedBrieQuality_GivenPositiveSellIn_IncreasesQualityByOne()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY, QualitySpecification.MAX_QUALITY - 1);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality + 1));
        }

        [Test]
        public void ChangeAgedBrieQuality_GivenNonPositiveSellIn_IncreasesQualityByTwo()
        {
            AlterableItem.SellIn = Fixture.CreateNonPositive();
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY, QualitySpecification.MAX_QUALITY - 2);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality + 2));
        }
    }
}
