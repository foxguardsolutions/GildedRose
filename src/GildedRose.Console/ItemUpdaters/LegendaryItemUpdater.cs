namespace GildedRose.Console.ItemUpdaters
{
    public class LegendaryItemUpdater : EndOfDayItemUpdater
    {
        public override ItemCategory Category => ItemCategory.Legendary;

        public override void PassTime(Item item) { }

        public override void UpdateItemQuality(Item item) { }
    }
}
