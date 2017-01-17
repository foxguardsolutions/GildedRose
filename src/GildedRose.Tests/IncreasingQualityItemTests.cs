using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public abstract class IncreasingQualityItemTests : AlterableItemTests
    {
        [Test]
        public void ChangeQualityOfIncreasingQualityItem_GivenQualityThatCouldIncreaseAboveMaximum_LeavesQualityAtMaximum()
        {
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MAX_QUALITY - 1, QualitySpecification.MAX_QUALITY);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(QualitySpecification.MAX_QUALITY));
        }
    }
}
