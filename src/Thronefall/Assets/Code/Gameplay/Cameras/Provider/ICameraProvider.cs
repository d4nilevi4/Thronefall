using UnityEngine;

namespace Thronefall.Gameplay.Cameras
{
    public interface ICameraProvider
    {
        Camera MainCamera { get; }
        
        void SetMainCamera(Camera camera);
    }
}