namespace CrudeWorld
{
    public interface IEater<in T> : ICreature where T : ICreature
    {
    }
}