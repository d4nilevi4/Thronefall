using Thronefall.Infrastructure;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Levels
{
    public class BattleLevelDataProviderInstaller : BindingsInstaller
    {
        public Transform HeroSpawnPoint;
        public Transform SkeletonSpawnPoint;
        private DiContainer _container;

        public override void InstallBindings(DiContainer container)
        {
            _container = container;
            
            container.Bind<IBattleLevelDataProvider>().To<BattleLevelDataProvider>().AsSingle();
        }

        private void Awake()
        {
            var provider = _container.Resolve<IBattleLevelDataProvider>();
            
            provider.SetHeroSpawnPoint(HeroSpawnPoint.position);
        }
    }
}