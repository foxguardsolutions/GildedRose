using GildedRose.Console;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class NonLegendaryTests : BaseTests
    {
        public string Name { get; set; }

        [SetUp]
        public void SetName()
        {
            Name = Fixture.Create<string>();
        }

        [Test]
        public void UpdateNonLegendaryItemQuality_DecrementsSellInAndMakesNoChangeToName()
        {
            var quality = Fixture.Create<int>();
            var sellIn = Fixture.Create<int>();
            var nonLegendaryItem = new Item { Name = Name, SellIn = sellIn, Quality = quality };

            UpdateInventoryContaining(nonLegendaryItem);

            AssertNameDidNotChange(nonLegendaryItem, Items[0]);
            AssertSellInChangedBy(nonLegendaryItem, Items[0], -1);
        }
    }
}
