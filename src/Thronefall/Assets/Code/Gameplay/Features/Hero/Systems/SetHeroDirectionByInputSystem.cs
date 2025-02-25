using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<InputEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext game, InputContext input)
        {
            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Direction));

            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input));
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            foreach (GameEntity hero in _heroes)
            {
                hero.isMoving = input.hasInputAxis;

                if (input.hasInputAxis) 
                    hero.ReplaceDirection(new Vector3(input.InputAxis.x, 0, input.InputAxis.y));
            }
        }
    }
}