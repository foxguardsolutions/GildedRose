using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedItemTests
    {
        [TestCase(1, Result = 21)]
        [TestCase(0, Result = 21)]
        [TestCase(-1, Result = 22)]
        public int AgedItemUpdateQualityIncreasesQualityCorrectly(int sellIn)
        {
            AgedItem item = new AgedItem("Really Bad Wine", sellIn, 20);
            item.UpdateQuality();
            return item.Quality;
        }
    }
}
