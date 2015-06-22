using System.Collections.Generic;
using System.Linq;

namespace CrudeWorld.Implementation
{
    public class Meal<TEater, TVictim> : InteractionBase where TEater : IEater<TVictim> where TVictim : ICreature
    {
        public Meal(TEater eater, TVictim victim)
            : this(new[] { eater }, new[] { victim })
        {
        }

        public Meal(IEnumerable<TEater> eaters, TVictim victim)
            : this(eaters, new[] { victim })
        {
        }

        public Meal(TEater eater, IEnumerable<TVictim> victims)
            : this(new[] { eater }, victims)
        {
        }

        public Meal(IEnumerable<TEater> eaters, IEnumerable<TVictim> victims)
        {
            FirstGroup = eaters.Select(eater => (ICreature) eater).ToList();
            SecondGroup = victims.Select(victim => (ICreature) victim).ToList();
        }

        protected override bool ExecuteCore()
        {
            if (FirstGroup.All(creature => creature.State == CreatureState.Dead))
                return false;

            foreach (var creature in SecondGroup)
                creature.State = CreatureState.Dead;
            return true;
        }
    }
}