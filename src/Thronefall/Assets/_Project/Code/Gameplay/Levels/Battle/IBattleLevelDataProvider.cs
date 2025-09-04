using UnityEngine;

namespace Thronefall.Gameplay.Levels
{
    public interface IBattleLevelDataProvider
    {
        Vector3 HeroSpawnPoint { get; }
        
        void SetHeroSpawnPoint(Vector3 startPoint);
    }
}