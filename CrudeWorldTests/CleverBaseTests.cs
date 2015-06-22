using CrudeWorld;
using NUnit.Framework;

namespace CrudeWorldTests
{
    [TestFixture]
    public class CleverBaseTests
    {
        private class MockClever : CleverBase
        {
            public const int StrengthValue = 75;

            public MockClever(string name) : base(name)
            {
            }

            public override int Strength
            {
                get { return StrengthValue; }
            }
        }

        private class MockWeapon : IWeapon
        {
            public const int StrengthValue = 155;

            public int CalculateBonus(IClever owner)
            {
                return StrengthValue;
            }
        }

        [Test]
        public void TestSimplePower()
        {
            var x = new MockClever("test");
            var power = x.CalculatePower();

            Assert.AreEqual(MockClever.StrengthValue, power);
        }

        [Test]
        public void TestWeaponPower()
        {
            var x = new MockClever("test") {WieldedWeapon = new MockWeapon()};
            var power = x.CalculatePower();

            Assert.AreEqual(MockClever.StrengthValue + MockWeapon.StrengthValue, power);
        }
    }
}