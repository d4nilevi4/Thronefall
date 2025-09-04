using Cysharp.Threading.Tasks;
using Thronefall.Common;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Hero;
using Thronefall.Gameplay.Levels;
using Thronefall.Gameplay.StaticData;

namespace Thronefall.Infrastructure
{
    public class EnterBattleState : LocalEnterState
    {
        private readonly IHeroFactory _heroFactory;
        private readonly IGameStateMachine _stateMachine;
        private readonly IBattleLevelDataProvider _battleLevelDataProvider;
        private readonly IWeaponFactory _weaponFactory;
        private readonly IStaticDataService _staticDataService;

        public EnterBattleState(
            IHeroFactory heroFactory,
            IGameStateMachine stateMachine, 
            IBattleLevelDataProvider battleLevelDataProvider,
            IWeaponFactory weaponFactory,
            IStaticDataService staticDataService)
        {
            _heroFactory = heroFactory;
            _stateMachine = stateMachine;
            _battleLevelDataProvider = battleLevelDataProvider;
            _weaponFactory = weaponFactory;
            _staticDataService = staticDataService;
        }

        public override async UniTask Enter()
        {
            PlaceHero();
            
            await _stateMachine.Enter<BattleLoopState>();
        }

        public override UniTask Exit()
        {
            return UniTask.CompletedTask;
        }
        
        private void PlaceHero()
        {
            GameEntity hero = _heroFactory.CreateHero(_battleLevelDataProvider.HeroSpawnPoint);
            HeroConfig config = _staticDataService.GetHeroConfig();
            _weaponFactory.CreateWeapon(config.WeaponConfig, hero.Id, CollisionLayer.Enemy.AsMask());
        }
    }
}