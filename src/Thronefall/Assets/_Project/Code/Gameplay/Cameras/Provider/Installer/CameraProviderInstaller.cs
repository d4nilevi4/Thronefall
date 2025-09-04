using Thronefall.Infrastructure;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

namespace Thronefall.Gameplay.Cameras
{
    public class CameraProviderInstaller : BindingsInstaller
    {
        public Camera MainCamera;
        public CinemachineCamera CinemachineCamera;
        private DiContainer _container;

        public override void InstallBindings(DiContainer container)
        {
            _container = container;
            container.Bind<ICameraProvider>().To<CameraProvider>().AsSingle();
        }

        private void Awake()
        {
            var provider = _container.Resolve<ICameraProvider>();
            
            provider.SetMainCamera(MainCamera);
            provider.SetCinemachineCamera(CinemachineCamera);
        }
    }
}