using Entitas;
using Thronefall.Common;
using UnityEngine;

namespace Thronefall.Gameplay.GroundDetection
{
    public class DrawGroundNormalGizmoSystem : IDrawGizmoSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public DrawGroundNormalGizmoSystem(GameContext contextParameter)
        {
            _entities = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Grounded,
                    GameMatcher.GroundHit,
                    GameMatcher.WorldPosition));
        }

        public void DrawGizmo()
        {
            foreach (GameEntity entity in _entities)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawRay(entity.WorldPosition, entity.GroundHit.normal);
                Gizmos.color = Color.white;
            }
        }
    }
}