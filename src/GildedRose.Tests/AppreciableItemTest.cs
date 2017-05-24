using GildedRose.Console;

namespace GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class AppreciableItemTest
    {
        [TestCase(10, 4, 0, Result = 10)]
        [TestCase(10, 4, 1, Result = 11)]
        [TestCase(40, 4, 10, Result = 50)]
        [TestCase(40, 4, 11, Result = 50)]
        public int TestAppreciableItem(int startingQuality, int sellInDays, int daysElapsed)
        {
            AppreciableItem item = new AppreciableItem("Wine", startingQuality, sellInDays);

            for (int i = 0; i < daysElapsed; i++)
            {
                item.UpdateAfterDayElapsed();
            }

            return item.Quality;
        }
    }
}
