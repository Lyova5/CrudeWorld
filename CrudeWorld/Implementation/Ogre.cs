namespace CrudeWorld.Implementation
{
    public class Ogre : CleverBase, IBigMonster, IEater<ICritter>, IEater<IMonster>
    {
        public Ogre(string name) : base(name)
        {
        }

        public override int Strength { get { return 3; } }
    }
}