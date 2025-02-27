using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Cameras
{
    public sealed class CamerasFeature : Feature
    {
        public CamerasFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CameraLookPointReactiveSystem>());
        }
    }
}