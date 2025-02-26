using Thronefall.Gameplay.Hero;

namespace Thronefall.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();

        HeroConfig GetHeroConfig();
    }
}