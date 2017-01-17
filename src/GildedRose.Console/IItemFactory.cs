namespace GildedRose.Console
{
    public interface IItemFactory
    {
        Item CreateAgedBrieItem(string name, int daysToSell, int quality);

        Item CreateBackstagePassItem(string name, int daysToSell, int quality);

        Item CreateConjuredItem(string name, int daysToSell, int quality);

        Item CreateLegendaryItem(string name, int daysToSell, int quality);

        Item CreateStandardItem(string name, int daysToSell, int quality);
    }
}
