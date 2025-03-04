using Entitas;
using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.HitDetection
{
    public class DrawWeaponSphereBladeGizmoSystem : IDrawGizmoSystem
    {
        private readonly IGroup<GameEntity> _weapons;

        public DrawWeaponSphereBladeGizmoSystem(GameContext game)
        {
            _weapons = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WeaponSphereBladeRadius,
                    GameMatcher.WeaponSphereBladeTransform));
        }

        public void DrawGizmo()
        {
            Gizmos.color = Color.green;
            
            foreach (GameEntity weapon in _weapons)
            {
                Gizmos.DrawWireSphere(weapon.WeaponSphereBladeTransform.position, weapon.WeaponSphereBladeRadius);
            }

            Gizmos.color = Color.white;
        }
    }
}