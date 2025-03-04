using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Targeting
{
    public class ChooseClosestEnemyTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _enemies;

        public ChooseClosestEnemyTargetSystem(GameContext contextParameter)
        {
            _heroes = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChooseClosestTarget,
                    GameMatcher.Hero,
                    GameMatcher.WorldPosition));

            _enemies = contextParameter.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.Id,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                GameEntity closestEnemy = ClosestEnemyTo(hero);

                if (closestEnemy != null)
                    hero.ReplaceTarget(closestEnemy.Id);
                else if (hero.hasTarget)
                    hero.RemoveTarget();
            }
        }

        private GameEntity ClosestEnemyTo(GameEntity hero)
        {
            GameEntity closestEnemy = null;
            float minDistance = float.MaxValue;

            foreach (GameEntity enemy in _enemies)
            {
                float currentDistance = Vector3.Distance(enemy.WorldPosition, hero.WorldPosition);
                
                if (currentDistance >= minDistance)
                    continue;
                
                closestEnemy = enemy;
                minDistance = currentDistance;
            }

            return closestEnemy;
        }
    }
}