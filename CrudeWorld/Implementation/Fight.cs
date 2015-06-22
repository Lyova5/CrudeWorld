using System.Collections.Generic;
using System.Linq;

namespace CrudeWorld.Implementation
{
    public class Fight : InteractionBase
    {
        public Fight(ICreature attacker, ICreature defender)
            : this(new[] { attacker }, new[] { defender })
        {
        }

        public Fight(IEnumerable<ICreature> attackers, ICreature defender)
            : this(attackers, new[] { defender })
        {
        }

        public Fight(ICreature attacker, IEnumerable<ICreature> defenders) : this(new[] {attacker}, defenders)
        {
        }

        public Fight(IEnumerable<ICreature> attackers, IEnumerable<ICreature> defenders)
        {
            FirstGroup = attackers.ToList();
            SecondGroup = defenders.ToList();
        }

        protected override bool ExecuteCore()
        {
            var firstPower = FirstGroup.Sum(x => GetCreaturePower(x));
            var secondPower = SecondGroup.Sum(x => GetCreaturePower(x));

            return firstPower > secondPower;
        }

        private static int GetCreaturePower(ICreature creature)
        {
            return creature.State == CreatureState.Alive ? creature.CalculatePower() : 0;
        }
    }
}