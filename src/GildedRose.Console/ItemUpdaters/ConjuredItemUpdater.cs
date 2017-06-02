namespace GildedRose.Console.ItemUpdaters
{
    public class ConjuredItemUpdater : ItemQualityDecreaser
    {
        public override ItemCategory Category => ItemCategory.Conjured;

        protected override int ItemQualityChangeRate { get => base.ItemQualityChangeRate * 2; }
    }
}
