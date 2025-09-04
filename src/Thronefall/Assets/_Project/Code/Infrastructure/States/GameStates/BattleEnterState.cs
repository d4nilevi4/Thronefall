using Thronefall.Common;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Levels;
using Thronefall.Gameplay.StaticData;

namespace Thronefall.Infrastructure
{
    public class BattleEnterState : SimpleState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IGameStateMachine _stateMachine;
        private readonly ILevelDataProvider _levelDataProvider;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IStaticDataService _staticDataService;

        public BattleEnterState(
            IHeroFactory heroFactory,
            IGameStateMachine stateMachine, 
            ILevelDataProvider levelDataProvider,
            IWeaponFactory weaponFactory,
            IStaticDataService staticDataService)
        {
            _heroFactory = heroFactory;
            _stateMachine = stateMachine;
            _levelDataProvider = levelDataProvider;
            _weaponFactory = weaponFactory;
            _staticDataService = staticDataService;
        }

        protected override void Enter()
        {
            PlaceHero();
            
            _stateMachine.Enter<BattleLoopState>();
        }
        

        private void PlaceHero()
        {
            GameEntity hero = _heroFactory.CreateHero(_levelDataProvider.StartPoint);
            HeroConfig config = _staticDataService.GetHeroConfig();
            _weaponFactory.CreateWeapon(config.WeaponConfig, hero.Id, CollisionLayer.Enemy.AsMask());
        }
    }
}