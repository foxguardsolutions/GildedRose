namespace GildedRose.Console
{
    public interface IItem
    {
        Item internalItem { get; set; }
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }

        void UpdateQuality();
        void UpdateSellIn();
    }
}
