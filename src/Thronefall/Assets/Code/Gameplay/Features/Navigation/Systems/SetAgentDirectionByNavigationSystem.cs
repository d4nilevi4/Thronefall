using Entitas;

namespace Thronefall.Gameplay.Navigation
{
    public class SetAgentDirectionByNavigationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _agents;

        public SetAgentDirectionByNavigationSystem(GameContext game)
        {
            _agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.RichNavigation,
                    GameMatcher.Direction,
                    GameMatcher.Agent));
        }

        public void Execute()
        {
            foreach (GameEntity agent in _agents)
            {
                bool hasInput = agent.RichNavigation.CurrentDirection.sqrMagnitude >= .001f;

                agent.isMoving = hasInput;

                if (hasInput)
                    agent.ReplaceDirection(agent.RichNavigation.CurrentDirection);
            }
        }
    }
}