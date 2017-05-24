using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BaseItemTests
    {
        [TestCase(10, Result = 19)]
        [TestCase(0, Result = 19)]
        [TestCase(-1, Result = 18)]
        public int BaseItemUpdateQualityReducesQualityCorrectly(int sellIn)
        {
            BaseItem item = new BaseItem("Fake name", sellIn, 20);
            item.UpdateQuality();
            return item.Quality;
        }

        [TestCase(10, Result = 9)]
        [TestCase(1, Result = 0)]
        [TestCase(0, Result = -1)]
        public int BaseItemUpdateSellInReducesSellInCorrectly(int sellIn)
        {
            BaseItem item = new BaseItem("Fake name", sellIn, 10);
            item.UpdateSellIn();
            return item.SellIn;
        }
    }
}
