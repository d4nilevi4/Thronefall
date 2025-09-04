using Unity.Cinemachine;
using UnityEngine;

namespace Thronefall.Gameplay.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        CinemachineCamera CinemachineCamera { get; }
        
        void SetMainCamera(Camera camera);
        void SetCinemachineCamera(CinemachineCamera cinemachineCamera);
    }
}