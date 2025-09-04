using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class WeaponSphereBladeRegistrar : EntityComponentRegistrar
    {
        public Transform WeaponBladeTransform;
        public float Radius;

        public override void RegisterComponents()
        {
            Entity.AddWeaponSphereBladeTransform(WeaponBladeTransform);
            Entity.AddWeaponSphereBladeRadius(Radius);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasWeaponSphereBladeRadius)
                Entity.RemoveWeaponSphereBladeRadius();

            if (Entity.hasWeaponSphereBladeTransform)
                Entity.RemoveWeaponSphereBladeTransform();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            if (WeaponBladeTransform != null)
                Gizmos.DrawWireSphere(WeaponBladeTransform.position, Radius);

            Gizmos.color = Color.white;
        }
    }
}