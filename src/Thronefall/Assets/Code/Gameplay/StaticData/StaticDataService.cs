using Thronefall.Gameplay.Hero;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;
        private HeroConfig _heroConfig;

        public StaticDataService(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        
        public void LoadAll()
        {
            LoadHeroConfig();
        }

        private void LoadHeroConfig()
        {
            _heroConfig = _assetProvider
                .LoadAsset<HeroConfig>("Gameplay/Hero/HeroConfig");
        }

        public HeroConfig GetHeroConfig() =>
            _heroConfig;
    }
}