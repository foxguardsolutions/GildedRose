using System.Linq;

namespace GildedRose.Console
{
    public static class StoreItemIdentifier
    {
        internal const string BACKSTAGE_PASS_TEXT = "Backstage pass";
        internal const string CONJURED_ITEM_TEXT = "Conjured";
        internal static readonly string[] AGED_ITEM_NAMES = { "Aged Brie" };
        internal static readonly string[] LEGENDARY_ITEM_NAMES = { "Sulfuras, Hand of Ragnaros" };

        public static ItemCategory GetCategory(Item item)
        {
            if (IsAgedItem(item))
                return ItemCategory.Aged;
            else if (IsBackstagePasses(item))
                return ItemCategory.BackstagePass;
            else if (IsConjuredItem(item))
                return ItemCategory.Conjured;
            else if (IsLegendaryItem(item))
                return ItemCategory.Legendary;
            else
                return ItemCategory.Normal;
        }

        private static bool IsAgedItem(Item item) => AGED_ITEM_NAMES.Contains(item.Name);

        private static bool IsBackstagePasses(Item item) => item.Name.StartsWith(BACKSTAGE_PASS_TEXT);

        private static bool IsConjuredItem(Item item) => item.Name.StartsWith(CONJURED_ITEM_TEXT);

        private static bool IsLegendaryItem(Item item) => LEGENDARY_ITEM_NAMES.Contains(item.Name);
    }
}
