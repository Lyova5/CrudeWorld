using System.Linq;
using CrudeWorld;
using CrudeWorld.Implementation;
using NUnit.Framework;

namespace CrudeWorldTests
{
    [TestFixture]
    public class FightTests
    {
        private class MockCreature : ICreature
        {
            public int Strength { get; set; }
            public string Name { get { return "test"; } }
            public CreatureState State { get; set; }
            public int CalculatePower()
            {
                return Strength;
            }
        }

        private MockCreature _x;
        private MockCreature _y;

        [SetUp]
        public void SetUp()
        {
            _x = new MockCreature { Strength = 1, State = CreatureState.Alive };
            _y = new MockCreature { Strength = 2, State = CreatureState.Alive };            
        }

        [Test]
        public void ConstructorTest()
        {
            var f = new Fight(_x, _y);
            Assert.IsTrue(f.FirstGroup.Contains(_x));
            Assert.IsTrue(f.SecondGroup.Contains(_y));
        }

        [Test]
        public void ExecuteTest1()
        {
            var f = new Fight(_x, _y);
            Assert.IsFalse(f.Execute());
            Assert.IsTrue(_x.State == CreatureState.Alive);
            Assert.IsTrue(_y.State == CreatureState.Alive);
        }

        [Test]
        public void ExecuteTest2()
        {
            var f = new Fight(_y, _x);
            Assert.IsTrue(f.Execute());
            Assert.IsTrue(_x.State == CreatureState.Alive);
            Assert.IsTrue(_y.State == CreatureState.Alive);
        }
    }
}