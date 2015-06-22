namespace CrudeWorld.Implementation
{
    public class MagicSword : IWeapon
    {
        public int CalculateBonus(IClever owner)
        {
            return owner.Strength + 3;
        }
    }
}