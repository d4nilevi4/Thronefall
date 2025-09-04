using UnityEngine;

namespace Thronefall.Gameplay.Levels
{
    public class BattleLevelDataProvider : IBattleLevelDataProvider
    {
        public Vector3 HeroSpawnPoint { get; private set; }
        public Vector3 SkeletonStartPoint { get; private set; }

        public void SetHeroSpawnPoint(Vector3 startPoint)
        {
            HeroSpawnPoint = startPoint;
        }

        public void SetSkeletonSpawnPoint(Vector3 position)
        {
            SkeletonStartPoint = position;
        }
    }
}