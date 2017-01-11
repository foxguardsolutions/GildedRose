using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    public static class AutoFixtureExtension
    {
        public static T CreateInRange<T>(this Fixture fixture, int lowerLimit, int upperLimit)
        {
            fixture.Customizations.Add(new RandomNumericSequenceGenerator(lowerLimit, upperLimit));
            var value = fixture.Create<T>();
            fixture.Customizations.RemoveAt(fixture.Customizations.Count - 1);
            return value;
        }

        public static int CreateNonPositive(this Fixture fixture)
        {
            var positive = fixture.Create<int>();
            var nonNegative = positive - 1;
            return -nonNegative;
        }
    }
}
