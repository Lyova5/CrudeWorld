using CrudeWorld;
using CrudeWorld.Implementation;
using NUnit.Framework;

namespace CrudeWorldTests
{
    [TestFixture]
    public class Situations
    {
        private Goblin _goblin1;
        private Goblin _goblin2;

        private Sheep _sheep1;
        private Sheep _sheep2;

        private Ogre _ogre1;
        private Ogre _ogre2;

        [SetUp]
        public void SetUp()
        {
            _goblin1 = new Goblin("Vasya");
            _goblin2 = new Goblin("Petya");

            _sheep1 = new Sheep("Dolly");
            _sheep2 = new Sheep("Molly");

            _ogre1 = new Ogre("UhUh");
            _ogre2 = new Ogre("YhYh");
        }

        [Test]
        public void Situation1()
        {
            var eating = new Meal<Goblin, Sheep>(_goblin1, _sheep1);
            Assert.IsTrue(eating.Execute());
            Assert.IsTrue(_goblin1.State == CreatureState.Alive);
            Assert.IsTrue(_sheep1.State == CreatureState.Dead);
        }

        [Test]
        public void Situation2()
        {
            var fight = new Fight(_goblin1, _goblin2)
            {
                NextStepOnSuccess = () => new Meal<Goblin, Sheep>(_goblin1, _sheep1),
                NextStepOnFail = () => new Meal<Goblin, Sheep>(_goblin2, _sheep1),
            };

            fight.Execute();
            Assert.IsTrue(_sheep1.State == CreatureState.Dead);
            Assert.IsTrue(_goblin1.State == CreatureState.Alive);
            Assert.IsTrue(_goblin2.State == CreatureState.Alive);
        }

        [Test]
        public void Situation3()
        {
            var goblins = new[] { _goblin1, _goblin2 };
            var fight = new Fight(_ogre1, goblins)
            {
                NextStepOnSuccess = () => new Meal<Ogre, Goblin>(_ogre1, goblins),
            };

            Assert.IsFalse(fight.Execute());
            Assert.IsTrue(_goblin1.State == CreatureState.Alive);
            Assert.IsTrue(_goblin2.State == CreatureState.Alive);
            Assert.IsTrue(_ogre1.State == CreatureState.Alive);
        }

        [Test]
        public void Situation4()
        {
            var goblins = new[] { _goblin1, _goblin2 };
            var ogres = new[] { _ogre1, _ogre2 };

            var fight = new Fight(ogres, goblins)
            {
                NextStepOnSuccess = () => new Meal<Ogre, Goblin>(ogres, goblins),
            };

            Assert.IsTrue(fight.Execute());
            Assert.IsTrue(_goblin1.State == CreatureState.Dead);
            Assert.IsTrue(_goblin2.State == CreatureState.Dead);
            Assert.IsTrue(_ogre1.State == CreatureState.Alive);
            Assert.IsTrue(_ogre2.State == CreatureState.Alive);
        }

        [Test]
        public void Situation5()
        {
            var ogres = new[] { _ogre1, _ogre2 };
            _goblin1.WieldedWeapon = new MagicSword();

            var fight = new Fight(ogres, _goblin1)
            {
                NextStepOnSuccess = () => new Meal<Ogre, Goblin>(ogres, _goblin1),
            };

            Assert.IsFalse(fight.Execute());
            Assert.IsTrue(_ogre1.State == CreatureState.Alive);
            Assert.IsTrue(_ogre2.State == CreatureState.Alive);
            Assert.IsTrue(_goblin1.State == CreatureState.Alive);
        }

        [Test]
        public void Situation6()
        {
            var goblinsAndSheeps = new ICreature[] {_goblin1, _goblin2, _sheep1, _sheep2};
            var ogres = new[] {_ogre1, _ogre2};

            var fight = new Fight(ogres, goblinsAndSheeps);

            Assert.IsFalse(fight.Execute());
            Assert.IsTrue(_ogre1.State == CreatureState.Alive);
            Assert.IsTrue(_ogre2.State == CreatureState.Alive);
            Assert.IsTrue(_goblin1.State == CreatureState.Alive);
            Assert.IsTrue(_goblin2.State == CreatureState.Alive);
            Assert.IsTrue(_sheep1.State == CreatureState.Alive);
            Assert.IsTrue(_sheep2.State == CreatureState.Alive);
        }
    }
}
