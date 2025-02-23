using System;

namespace Thronefall.Gameplay.Common
{
    public interface ITimeService
    {
        float DeltaTime { get; }
        DateTime UtcNow { get; }
        void StopTime();
        void StartTime();
    }
}