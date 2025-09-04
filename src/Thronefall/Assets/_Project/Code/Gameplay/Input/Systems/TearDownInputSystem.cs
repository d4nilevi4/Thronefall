using Entitas;

namespace Thronefall.Gameplay.Input
{
    public class TearDownInputSystem : ITearDownSystem
    {
        private readonly IGroup<InputEntity> _inputs;

        public TearDownInputSystem(InputContext input)
        {
            _inputs = input.GetGroup(InputMatcher.Input);
        }
        
        public void TearDown()
        {
            foreach (InputEntity input in _inputs)
            {
                input.isDestructed = true;
            }
        }
    }
}