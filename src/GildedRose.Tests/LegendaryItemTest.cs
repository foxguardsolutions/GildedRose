using GildedRose.Console;

namespace GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class LegendaryItemTest
    {
        [TestCase(4, 0, Result = 80)]
        [TestCase(4, 1, Result = 80)]
        [TestCase(4, 2, Result = 80)]
        [TestCase(4, 4, Result = 80)]
        [TestCase(4, 5, Result = 80)]
        public int TestLegendaryItem(int sellInDays, int daysElapsed)
        {
            LegendaryItem item = new LegendaryItem("Sulfuras", sellInDays);

            for (int i = 0; i < daysElapsed; i++)
            {
                item.UpdateAfterDayElapsed();
            }

            return item.Quality;
        }
    }
}
