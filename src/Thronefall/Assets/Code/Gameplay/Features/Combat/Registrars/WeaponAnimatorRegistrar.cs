using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Combat
{
    public class WeaponAnimatorRegistrar : EntityComponentRegistrar
    {
        public WeaponAnimator WeaponAnimator;
        
        public override void RegisterComponents()
        {
            Entity.AddWeaponAnimator(WeaponAnimator);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasWeaponAnimator)
                Entity.RemoveWeaponAnimator();
        }
    }
}