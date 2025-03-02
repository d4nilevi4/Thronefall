namespace Thronefall.Gameplay.Combat
{
    public interface IWeaponFactory
    {
        GameEntity CreateWeapon(WeaponTypeId typeId, int owner);
    }
}