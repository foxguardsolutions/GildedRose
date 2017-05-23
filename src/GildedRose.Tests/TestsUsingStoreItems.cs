using GildedRose.Console;
using GildedRose.Console.ItemUpdaters;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class TestsUsingStoreItems
    {
        private const string BACKSTAGE_PASS_TEXT = StoreItemIdentifier.BACKSTAGE_PASS_TEXT;
        private readonly string AGED_BRIE = StoreItemIdentifier.AGED_ITEM_NAMES[0];
        private readonly string SULFURAS = StoreItemIdentifier.LEGENDARY_ITEM_NAMES[0];
        protected const int APPROACHING_DEADLINE_MARK = BackstagePassUpdater.APPROACHING_DEADLINE_MARK;
        protected const int IMMINENT_DEADLINE_MARK = BackstagePassUpdater.IMMINENT_DEADLINE_MARK;
        protected const int MAXIMUM_ITEM_QUALITY = EndOfDayItemUpdater.MAXIMUM_ITEM_QUALITY;
        protected const int MINIMUM_ITEM_QUALITY = EndOfDayItemUpdater.MINIMUM_ITEM_QUALITY;
        protected const int ITEM_QUALITY_CHANGE_RATE = EndOfDayItemUpdater.ITEM_QUALITY_CHANGE_RATE;

        protected Fixture Fixture { get; set; }
        protected Item Item { get; set; }

        [SetUp]
        public void SetUp()
        {
            var qualityRange = MAXIMUM_ITEM_QUALITY - MINIMUM_ITEM_QUALITY + 1;
            Fixture = new Fixture();
            Item = Fixture.Create<Item>();
            Item.Quality = Item.Quality % qualityRange + MINIMUM_ITEM_QUALITY;
        }

        protected void GivenAgedBrie()
        {
            Item.Name = AGED_BRIE;
        }

        protected void GivenBackstagePass()
        {
            Item.Name = Fixture.Create($"{BACKSTAGE_PASS_TEXT} ");
        }

        protected void GivenItemOfQuality(int quality)
        {
            Item.Quality = quality;
        }

        protected void GivenItemOfQualityAtLeast(int lowestQuality)
        {
            while (Item.Quality < lowestQuality)
                Item.Quality++;
        }

        protected void GivenItemOfQualityAtLeastWithNegativeSellIn(int lowestQuality)
        {
            GivenItemOfQualityAtLeast(lowestQuality);
            GivenItemWithNegativeSellIn();
        }

        protected void GivenItemOfQualityAtMost(int highestQuality)
        {
            while (Item.Quality > highestQuality)
                Item.Quality--;
        }

        protected void GivenItemWithinSellInRange(int lower, int upper)
        {
            var rangeLength = upper - lower + 1;
            Item.SellIn = Item.SellIn % rangeLength + lower;
        }

        protected void GivenItemWithNegativeSellIn()
        {
            Item.SellIn = (-Item.SellIn);
        }

        protected void GivenSulfuras()
        {
            Item.Name = SULFURAS;
            Item.SellIn = 0;
            Item.Quality = 80;
        }
    }
}
