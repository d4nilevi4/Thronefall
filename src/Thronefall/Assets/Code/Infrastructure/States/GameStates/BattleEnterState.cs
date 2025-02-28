using Thronefall.Gameplay.Enemies;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Levels;

namespace Thronefall.Infrastructure
{
    public class BattleEnterState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;

        public BattleEnterState(
            IHeroFactory heroFactory,
            IEnemyFactory enemyFactory,
            IGameStateMachine stateMachine, 
            ILevelDataProvider levelDataProvider)
        {
            _heroFactory = heroFactory;
            _enemyFactory = enemyFactory;
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
        }

        protected override void Enter()
        {
            PlaceHero();

            _enemyFactory.CreateEnemy(EnemyTypeId.Skeleton, _levelDataProvider.SkeletonStartPoint);
            
            _stateMachine.Enter<BattleLoopState>();
        }

        private void PlaceHero()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
        }
    }
}