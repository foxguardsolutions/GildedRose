using System.Linq;

namespace GildedRose.Console
{
    public class ItemFactory
    {
        private static string[] _unalterableItemNames = new string[] { "Sulfuras, Hand of Ragnaros" };

        public Item Create(string name, int daysToSell, int quality)
        {
            if (_unalterableItemNames.Contains(name))
                return new UnalterableItem { Name = name, SellIn = daysToSell, Quality = quality };

            return new AlterableItem { Name = name, SellIn = daysToSell, Quality = quality };
        }
    }
}
