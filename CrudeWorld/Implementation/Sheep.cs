namespace CrudeWorld.Implementation
{
    public class Sheep : ICritter
    {
        public Sheep(string name)
        {
            Name = name;
            State = CreatureState.Alive;
        }

        public int Strength { get { return 1; } }

        public string Name { get; private set; }

        public CreatureState State { get; set; }

        public int CalculatePower()
        {
            return Strength;
        }
    }
}