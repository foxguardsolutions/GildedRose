using NUnit.Framework;
using Ploeh.AutoFixture;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BaseTests
    {
        protected Fixture Fixture { get; private set; }

        [SetUp]
        public void BaseSetUp()
        {
            Fixture = new Fixture();
        }
    }
}
