namespace CrudeWorld
{
    public interface IClever : ICreature
    {
        IWeapon WieldedWeapon { get; set; }
    }
}