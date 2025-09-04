using Thronefall.Common;
using Thronefall.Infrastructure;

namespace Thronefall.Gameplay.Cameras
{
    public sealed class CamerasFeature : CustomFeature
    {
        public CamerasFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<CameraLookPointReactiveSystem>());
        }
    }
}