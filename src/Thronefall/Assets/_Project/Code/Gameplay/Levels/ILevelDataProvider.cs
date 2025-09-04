using UnityEngine;

namespace Thronefall.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        Vector3 StartPoint { get; }
        Vector3 SkeletonStartPoint { get; }
        
        void SetStartPoint(Vector3 startPoint);
        void SetSkeletonStartPoint(Vector3 position);
    }
}