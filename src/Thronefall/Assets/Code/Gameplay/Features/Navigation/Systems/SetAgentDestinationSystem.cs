using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Navigation
{
    public class SetAgentDestinationSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _agents;

        public SetAgentDestinationSystem(GameContext game)
        {
            _agents = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.AgentDestination,
                    GameMatcher.RichNavigation,
                    GameMatcher.Agent));
        }

        public void Execute()
        {
            foreach (GameEntity agent in _agents)
            {
                if (DestinationNotChanged(agent))
                    continue;

                agent.RichNavigation.destination = agent.AgentDestination;
                agent.RichNavigation.SearchPath();
            }
        }

        private bool DestinationNotChanged(GameEntity agent) =>
            Mathf.Approximately(Vector3.Distance(agent.AgentDestination, agent.RichNavigation.destination), 0);
    }
}