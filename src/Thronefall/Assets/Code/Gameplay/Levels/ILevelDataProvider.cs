using UnityEngine;

namespace Thronefall.Gameplay.Levels
{
    public interface ILevelDataProvider
    {
        Vector3 StartPoint { get; }
        
        void SetStartPoint(Vector3 startPoint);
    }
}