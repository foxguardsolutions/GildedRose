using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemTests
    {
        [TestCase(20, Result = 18)]
        [TestCase(10, Result = 8)]
        [TestCase(-1, Result = 0)]
        public int ConjuredItemUpdateQualityDecreasesQualityCorrectly(int quality)
        {
            ConjuredItem item = new ConjuredItem("Alter-ego", 10, quality);
            item.UpdateQuality();
            return item.Quality;
        }
    }
}
