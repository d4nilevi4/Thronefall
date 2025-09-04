using Thronefall.Infrastructure;
using UnityEngine;

namespace Thronefall.Gameplay.Cameras
{
    public class CameraLookPointRegistrar : EntityComponentRegistrar
    {
        public Transform CameraLookPoint;
        
        public override void RegisterComponents()
        {
            Entity.AddCameraLookPoint(CameraLookPoint);
        }

        public override void UnregisterComponents()
        {
            if (Entity.hasCameraLookPoint)
                Entity.RemoveCameraLookPoint();
        }
    }
}