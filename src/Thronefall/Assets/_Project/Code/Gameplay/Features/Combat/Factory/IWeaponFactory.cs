namespace Thronefall.Gameplay.Combat
{
    public interface IWeaponFactory
    {
        GameEntity CreateWeapon(WeaponConfig weaponConfig, int owner, int targetLayerMask);
    }
}