using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class LegendaryItemTests
    {
        [TestCase(10, Result = 20)]
        [TestCase(0, Result = 20)]
        [TestCase(-10, Result = 20)]
        public int LegendaryItemQualityIsConstant(int sellIn)
        {
            LegendaryItem item = new LegendaryItem("Dirt", sellIn, 20);
            item.UpdateQuality();
            return item.Quality;
        }

        [TestCase(10, Result = 0)]
        [TestCase(0, Result = 0)]
        [TestCase(-10, Result = 0)]
        public int LegendaryItemSellInIsConstant(int sellIn)
        {
            LegendaryItem item = new LegendaryItem("Dirt", sellIn, 20);
            item.UpdateSellIn();
            return item.SellIn;
        }
    }
}
