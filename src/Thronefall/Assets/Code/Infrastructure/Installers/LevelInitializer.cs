using Thronefall.Gameplay.Cameras;
using Thronefall.Gameplay.Levels;
using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class LevelInitializer : MonoBehaviour
    {
        public Camera MainCamera;
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
            _levelDataProvider.SetStartPoint(StartPoint.position);
        }
    }
}