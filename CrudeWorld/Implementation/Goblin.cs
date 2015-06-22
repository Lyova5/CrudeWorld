namespace CrudeWorld.Implementation
{
    public class Goblin : CleverBase, IMonster, IEater<ICritter>
    {
        public Goblin(string name) : base(name)
        {
        }

        public override int Strength
        {
            get { return 2; }
        }
    }
}