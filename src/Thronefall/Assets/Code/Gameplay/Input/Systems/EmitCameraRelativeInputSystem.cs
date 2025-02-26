using Entitas;
using Thronefall.Gameplay.Cameras;
using UnityEngine;

namespace Thronefall.Gameplay.Input
{
    public class EmitCameraRelativeInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly ICameraProvider _cameraProvider;
        private readonly IGroup<InputEntity> _inputs;

        public EmitCameraRelativeInputSystem(
            InputContext input, 
            IInputService inputService,
            ICameraProvider cameraProvider)
        {
            _inputService = inputService;
            _cameraProvider = cameraProvider;

            _inputs = input.GetGroup(InputMatcher
                .AllOf(
                    InputMatcher.Input,
                    InputMatcher.CameraRelativeInput));
        }

        public void Execute()
        {
            Camera camera = _cameraProvider.MainCamera;
            
            foreach (InputEntity input in _inputs)
            {
                if (_inputService.HasAxisInput)
                {
                    Vector2 worldInput = _inputService.GetInputAxis();
                    Vector3 forward = camera.transform.forward;
                    Vector3 right = camera.transform.right;

                    forward.y = 0;
                    right.y = 0;
                    forward.Normalize();
                    right.Normalize();

                    Vector3 relativeMovement = (forward * worldInput.y + right * worldInput.x);
                    input.ReplaceInputAxis(new Vector2(relativeMovement.x, relativeMovement.z));
                }
                else if (input.hasInputAxis)
                {
                    input.RemoveInputAxis();
                }
            }
        }
    }
}