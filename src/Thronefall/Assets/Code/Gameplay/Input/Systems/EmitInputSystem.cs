using Entitas;

namespace Thronefall.Gameplay.Input
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<InputEntity> _inputs;

        public EmitInputSystem(InputContext input, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = input.GetGroup(InputMatcher.Input);
        }

        public void Execute()
        {
            foreach (InputEntity input in _inputs)
            {
                if (_inputService.HasAxisInput)
                    input.ReplaceInputAxis(_inputService.GetInputAxis());
                else if (input.hasInputAxis)
                    input.RemoveInputAxis();
            }
        }
    }
}