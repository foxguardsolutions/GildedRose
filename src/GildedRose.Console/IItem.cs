namespace GildedRose.Console
{
    public interface IItem
    {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }

        void UpdateQuality();
        void UpdateSellIn();
    }
}
