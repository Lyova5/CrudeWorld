using System.Linq;
using CrudeWorld;
using CrudeWorld.Implementation;
using NUnit.Framework;

namespace CrudeWorldTests
{
    [TestFixture]
    public class MealTests
    {
        private class MockCreature : IEater<MockCreature>
        {
            public int Strength { get { return 0; } }
            public string Name { get { return "test"; } }
            public CreatureState State { get; set; }
            public int CalculatePower()
            {
                return 0;
            }
        }

        [Test]
        public void ConstructorTest()
        {
            var x = new MockCreature { State = CreatureState.Alive };
            var y = new MockCreature { State = CreatureState.Alive };

            var meal = new Meal<MockCreature, MockCreature>(x, y);
            Assert.IsTrue(meal.FirstGroup.Contains(x));
            Assert.IsTrue(meal.SecondGroup.Contains(y));
        }

        [Test]
        public void ExecuteTest()
        {
            var x = new MockCreature {State = CreatureState.Alive};
            var y = new MockCreature {State = CreatureState.Alive};

            var meal = new Meal<MockCreature, MockCreature>(x, y);
            meal.Execute();
            Assert.IsTrue(x.State == CreatureState.Alive);
            Assert.IsFalse(y.State == CreatureState.Alive);
        }

        [Test]
        public void DeadEaterTest()
        {
            var x = new MockCreature { State = CreatureState.Dead };
            var y = new MockCreature { State = CreatureState.Alive };

            var meal = new Meal<MockCreature, MockCreature>(x, y);
            meal.Execute();
            Assert.IsFalse(x.State == CreatureState.Alive);
            Assert.IsTrue(y.State == CreatureState.Alive);
        }
    }
}