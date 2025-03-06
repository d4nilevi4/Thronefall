using Thronefall.Common;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Enemies;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Levels;

namespace Thronefall.Infrastructure
{
    public class BattleEnterState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IWeaponFactory _weaponFactory;

        public BattleEnterState(
            IHeroFactory heroFactory,
            IGameStateMachine stateMachine, 
            ILevelDataProvider levelDataProvider,
            IWeaponFactory weaponFactory)
        {
            _heroFactory = heroFactory;
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
            _weaponFactory = weaponFactory;
        }

        protected override void Enter()
        {
            PlaceHero();
            
            _stateMachine.Enter<BattleLoopState>();
        }
        

        private void PlaceHero()
        {
            GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            _weaponFactory.CreateWeapon(WeaponTypeId.SmallAxe, hero.Id, CollisionLayer.Enemy.AsMask());
        }
    }
}