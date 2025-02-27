using Entitas;
using UnityEngine;

namespace Thronefall.Gameplay.Cameras
{
    public class CameraLookPointInitializeSystem : IInitializeSystem
    {
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<GameEntity> _lookPoints;

        public CameraLookPointInitializeSystem(GameContext game, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;

            _lookPoints = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero,
                    GameMatcher.CameraLookPoint));
        }
        
        public void Initialize()
        {
            Debug.Log("InitializeI");
            
            foreach (GameEntity lookPoint in _lookPoints)
            {
                Debug.Log("Initialize");
                _cameraProvider.CinemachineCamera.Follow = lookPoint.CameraLookPoint;
            }
        }
    }
}