using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.Enemies;
using Thronefall.Gameplay.Hero;

namespace Thronefall.Gameplay.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();

        HeroConfig GetHeroConfig();
        EnemyConfig GetEnemyConfig(EnemyTypeId typeId);
    }
}