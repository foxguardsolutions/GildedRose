namespace GildedRose.Console
{
    public class ItemFactory
    {
        public Item Create(string name, int daysToSell, int quality)
        {
            return new Item { Name = name, SellIn = daysToSell, Quality = quality };
        }
    }
}
