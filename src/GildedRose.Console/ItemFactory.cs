namespace GildedRose.Console
{
    public class ItemFactory : IItemFactory
    {
        public Item CreateAgedBrieItem(string name, int daysToSell, int quality)
        {
            return new AgedBrieItem(name, daysToSell, quality);
        }

        public Item CreateBackstagePassItem(string name, int daysToSell, int quality)
        {
            return new BackstagePassItem(name, daysToSell, quality);
        }

        public Item CreateConjuredItem(string name, int daysToSell, int quality)
        {
            return new ConjuredItem(name, daysToSell, quality);
        }

        public Item CreateLegendaryItem(string name, int daysToSell, int quality)
        {
            return new LegendaryItem(name, daysToSell, quality);
        }

        public Item CreateStandardItem(string name, int daysToSell, int quality)
        {
            return new StandardItem(name, daysToSell, quality);
        }
    }
}
