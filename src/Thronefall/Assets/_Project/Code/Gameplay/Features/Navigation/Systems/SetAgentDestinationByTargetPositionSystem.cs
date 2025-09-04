using Entitas;

namespace Thronefall.Gameplay.Navigation
{
    public class SetAgentDestinationByTargetPositionSystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IGroup<GameEntity> _agents;

        public SetAgentDestinationByTargetPositionSystem(GameContext game)
        {
            _game = game;
            _agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Agent,
                    GameMatcher.AgentDestination,
                    GameMatcher.Target));
        }

        public void Execute()
        {
            foreach (GameEntity agent in _agents)
            {
                GameEntity agentTarget = _game.GetEntityWithId(agent.Target);

                if (agentTarget == null || !agentTarget.hasWorldPosition)
                    continue;

                agent.ReplaceAgentDestination(agentTarget.WorldPosition);
            }
        }
    }
}