using Entitas;
using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.Combat
{
    public class DrawAttackRadiusGizmosSystem : IDrawGizmoSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DrawAttackRadiusGizmosSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AttackRadius,
                    GameMatcher.WorldPosition));
        }

        public void DrawGizmo()
        {
            Gizmos.color = Color.red;
            
            foreach (GameEntity entity in _entities)
            {
                Gizmos.DrawWireSphere(entity.WorldPosition, entity.AttackRadius);
            }

            Gizmos.color = Color.white;
        }
    }
}