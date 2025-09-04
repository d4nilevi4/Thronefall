using Entitas;

namespace Thronefall.Gameplay.Targeting
{
    public class ChooseHeroTargetSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly IGroup<GameEntity> _heroes;

        public ChooseHeroTargetSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ChooseHeroTarget));

            _heroes = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.Id));
        }

        public void Execute()
        {
            bool heroExists = _heroes.count > 0;
            
            foreach (GameEntity entity in _entities)
            {
                if (heroExists)
                {
                    foreach (GameEntity hero in _heroes)
                    {
                        entity.ReplaceTarget(hero.Id);
                    }
                }
                else if (entity.hasTarget)
                {
                    entity.RemoveTarget();
                }
            }
        }
    }
}