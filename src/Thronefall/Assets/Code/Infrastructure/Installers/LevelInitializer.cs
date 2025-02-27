using Thronefall.Gameplay.Cameras;
using Thronefall.Gameplay.Levels;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class LevelInitializer : MonoBehaviour
    {
        public Camera MainCamera;
        public CinemachineCamera CinemachineCamera;
        public Transform StartPoint;
        
        private ILevelDataProvider _levelDataProvider;
        private ICameraProvider _cameraProvider;

        [Inject]
        private void Construct(ILevelDataProvider levelDataProvider, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _levelDataProvider = levelDataProvider;
        }

        private void Awake()
        {
            _cameraProvider.SetMainCamera(MainCamera);
            _cameraProvider.SetCinemachineCamera(CinemachineCamera);
            _levelDataProvider.SetStartPoint(StartPoint.position);
        }
    }
}