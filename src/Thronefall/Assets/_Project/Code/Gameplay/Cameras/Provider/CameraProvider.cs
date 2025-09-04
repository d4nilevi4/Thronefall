using Unity.Cinemachine;
using UnityEngine;

namespace Thronefall.Gameplay.Cameras
{
    public class CameraProvider : ICameraProvider
    {
        public Camera MainCamera { get; private set; }
        public CinemachineCamera CinemachineCamera { get; private set; }

        public void SetMainCamera(Camera camera)
        {
            MainCamera = camera;
        }

        public void SetCinemachineCamera(CinemachineCamera cinemachineCamera)
        {
            CinemachineCamera = cinemachineCamera;
        }
    }
}