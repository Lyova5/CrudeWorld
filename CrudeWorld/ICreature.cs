namespace CrudeWorld
{
    public interface ICreature
    {
        int Strength { get; }

        string Name { get; }

        CreatureState State { get; set; }

        int CalculatePower();
    }
}