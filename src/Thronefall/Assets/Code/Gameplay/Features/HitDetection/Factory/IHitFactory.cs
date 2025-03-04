namespace Thronefall.Gameplay.HitDetection
{
    public interface IHitFactory
    {
        GameEntity CreateWeaponHit(int weaponId, int targetId);
    }
}