using UnityEngine;

namespace Thronefall.Gameplay.Levels
{
    public class LevelDataProvider : ILevelDataProvider
    {
        public Vector3 StartPoint { get; private set; }
        public Vector3 SkeletonStartPoint { get; private set; }

        public void SetStartPoint(Vector3 startPoint)
        {
            StartPoint = startPoint;
        }

        public void SetSkeletonStartPoint(Vector3 position)
        {
            SkeletonStartPoint = position;
        }
    }
}