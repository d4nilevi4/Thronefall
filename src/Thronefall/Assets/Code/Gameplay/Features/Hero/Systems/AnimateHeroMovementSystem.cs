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
                    GameMatcher.HeroAnimator));

            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.InputAxis));
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
            foreach (InputEntity input in _inputs)
                hero.HeroAnimator.SetMoveAxis(input.InputAxis.x, input.InputAxis.y);
        }
    }
}