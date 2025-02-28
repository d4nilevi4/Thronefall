using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class AnimateHeroMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public AnimateHeroMovementSystem(GameContext game, InputContext input)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.HeroAnimator,
                    GameMatcher.Velocity,
                    GameMatcher.Transform));
            
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                if (hero.isMoving)
                {
                    hero.HeroAnimator.PlayMove();

                    SetMoveAxis(hero);
                }
                else
                {
                    hero.HeroAnimator.PlayIdle();
                }
            }
        }

        private void SetMoveAxis(GameEntity hero)
        {
            Vector3 flatVelocity = new Vector3(hero.Velocity.x, 0, hero.Velocity.z);
            
            Vector3 forward = hero.Transform.forward;
            Vector3 right = hero.Transform.right;
            
            forward.y = 0;
            right.y = 0;
            
            forward.Normalize();
            right.Normalize();

            float forwardAmount = Vector3.Dot(flatVelocity.normalized, forward);
            float rightAmount = Vector3.Dot(flatVelocity.normalized, right);

            hero.HeroAnimator.SetMoveAxis(rightAmount, forwardAmount);
        }
    }
}