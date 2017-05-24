using GildedRose.Console;

namespace GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PerishableItemTest
    {
        [TestCase(10, 4, 0, Result = 10)]
        [TestCase(10, 4, 1, Result = 9)]
        [TestCase(10, 4, 2, Result = 8)]
        [TestCase(10, 4, 4, Result = 0)]
        [TestCase(10, 4, 5, Result = 0)]
        public int TestPerishableItem(int startingQuality, int sellInDays, int daysElapsed)
        {
            PerishableItem item = new PerishableItem("Banana", startingQuality, sellInDays);

            for (int i = 0; i < daysElapsed; i++)
            {
                item.UpdateAfterDayElapsed();
            }

            return item.Quality;
        }

        [TestCase(10, 4, 0, Result = 10)]
        [TestCase(10, 4, 1, Result = 8)]
        [TestCase(10, 4, 2, Result = 6)]
        [TestCase(10, 4, 4, Result = 0)]
        [TestCase(10, 4, 5, Result = 0)]
        public int TestPerishableConjuredItem(int startingQuality, int sellInDays, int daysElapsed)
        {
            PerishableItem item = new PerishableItem("Banana", startingQuality, sellInDays);

            item.Conjured = true;

            for (int i = 0; i < daysElapsed; i++)
            {
                item.UpdateAfterDayElapsed();
            }

            return item.Quality;
        }
    }
}
