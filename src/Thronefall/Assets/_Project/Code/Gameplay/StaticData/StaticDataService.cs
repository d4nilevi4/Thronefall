using System.Collections.Generic;
using System.Linq;
using Thronefall.Gameplay.Enemies;
using Thronefall.Gameplay.Hero;
using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        
        private HeroConfig _heroConfig;
        private Dictionary<EnemyTypeId, EnemyConfig> _enemyConfigs;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void LoadAll()
        {
            LoadHeroConfig();
            LoadEnemyConfigs();
        }

        public HeroConfig GetHeroConfig() =>
            _heroConfig;

        public EnemyConfig GetEnemyConfig(EnemyTypeId typeId) =>
            _enemyConfigs[typeId];

        private void LoadHeroConfig()
        {
            _heroConfig = _assetProvider
                .LoadAsset<HeroConfig>("Gameplay/Hero/HeroConfig");
        }

        private void LoadEnemyConfigs()
        {
            _enemyConfigs = _assetProvider
                .LoadAll<EnemyConfig>("Gameplay/Enemies")
                .ToDictionary(x=> x.EnemyTypeId, x => x);
        }
    }
}