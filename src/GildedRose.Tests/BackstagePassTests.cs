using System.Collections.Generic;
using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackstagePassItemTests : IncreasingQualityItemTests
    {
        [SetUp]
        public void SetName()
        {
            AlterableItem = Fixture.Create<BackstagePassItem>();
        }

        [TestCaseSource(nameof(ChangeBackstagePassQualityTestCases))]
        public void ChangeBackstagePassItemQuality_GivenSellInWithinRange_IncreasesQualityBy(
            int minDays, int maxDays, int expectedChange)
        {
            AlterableItem.SellIn = Fixture.CreateInRange<int>(minDays, maxDays);
            var initialQuality = Fixture.CreateInRange<int>(QualitySpecification.MIN_QUALITY, QualitySpecification.MAX_QUALITY - expectedChange);
            AlterableItem.Quality = initialQuality;

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(initialQuality + expectedChange));
        }

        private static IEnumerable<TestCaseData> ChangeBackstagePassQualityTestCases()
        {
            yield return new TestCaseData(BackstagePassItem.NO_DAYS + 1, BackstagePassItem.FEW_DAYS, 3)
                .SetName("ChangeBackstagePassItemQuality_GivenThreeOrFewerDaysUntilConcert_IncreasesQualityByThree");
            yield return new TestCaseData(BackstagePassItem.FEW_DAYS + 1, BackstagePassItem.MANY_DAYS, 2)
                .SetName("ChangeBackstagePassItemQuality_GivenSixToTenDaysUntilConcert_IncreasesQualityByTwo");
            yield return new TestCaseData(BackstagePassItem.MANY_DAYS + 1, byte.MaxValue, 1)
                .SetName("ChangeBackstagePassItemQuality_GivenElevenOrMoreDaysUntilConcert_IncreasesQualityByOne");
        }

        [Test]
        public void ChangeBackstagePassItemQuality_GivenAfterConcert_LeavesQualityAtMinimum()
        {
            AlterableItem.SellIn = Fixture.CreateNonPositive();

            AlterableItem.ChangeQuality();

            Assert.That(AlterableItem.Quality, Is.EqualTo(QualitySpecification.MIN_QUALITY));
        }
    }
}
