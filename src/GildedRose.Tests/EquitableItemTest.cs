using GildedRose.Console;

namespace GildedRose.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class EquitableItemTest
    {
        [TestCase(10, 11, Result = 11)]
        [TestCase(10, 10, Result = 12)]
        [TestCase(10, 9, Result = 12)]
        [TestCase(10, 3, Result = 13)]
        [TestCase(10, 0, Result = 13)]
        [TestCase(10, -1, Result = 0)]
        [TestCase(48, 2, Result = 50)]
        public int TestEquitableItem(int startingQuality, int sellInDays)
        {
            EquitableItem item = new EquitableItem("Backstage Pass", startingQuality, sellInDays);

            item.UpdateAfterDayElapsed();

            return item.Quality;
        }
    }
}
