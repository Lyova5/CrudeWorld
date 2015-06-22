namespace CrudeWorld
{
    public abstract class CleverBase : IClever
    {
        public abstract int Strength { get; }
        public string Name { get; private set; }
        public IWeapon WieldedWeapon { get; set; }
        public CreatureState State { get; set; }

        public int CalculatePower()
        {
            int res = Strength;
            if (WieldedWeapon != null)
                res += WieldedWeapon.CalculateBonus(this);
            return res;
        }

        protected CleverBase(string name)
        {
            Name = name;
            State = CreatureState.Alive;
        }
    }
}