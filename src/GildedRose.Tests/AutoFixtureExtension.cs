using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public static class AutoFixtureExtension
    {
        public static T CreateBetween<T>(this Fixture fixture, int lowerLimit, int upperLimit)
        {
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(lowerLimit, upperLimit));
            var value = fixture.Create<T>();
            fixture.Customizations.RemoveAt(fixture.Customizations.Count - 1);
            return value;
        }
    }
}
