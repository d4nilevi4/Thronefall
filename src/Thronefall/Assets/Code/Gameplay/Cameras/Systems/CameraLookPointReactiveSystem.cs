using System.Collections.Generic;
using Entitas;

namespace Thronefall.Gameplay.Cameras
{
    public class CameraLookPointReactiveSystem : ReactiveSystem<GameEntity>
    {
        private readonly ICameraProvider _cameraProvider;

        public CameraLookPointReactiveSystem(GameContext game, ICameraProvider cameraProvider) : base(game)
        {
            _cameraProvider = cameraProvider;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
            context.CreateCollector(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.CameraLookPoint).Added());

        protected override bool Filter(GameEntity lookPoint) => lookPoint.hasCameraLookPoint && lookPoint.isHero;

        protected override void Execute(List<GameEntity> lookPoints)
        {
            foreach (GameEntity lookPoint in lookPoints)
            {
                _cameraProvider.CinemachineCamera.Follow = lookPoint.CameraLookPoint;
            }
        }
    }
}