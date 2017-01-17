namespace GildedRose.Console
{
    public abstract class UnalterableItem : Item
    {
        public UnalterableItem(string name, int daysToSell, int quality)
        {
            Name = name;
            SellIn = daysToSell;
            Quality = quality;
        }
    }
}
