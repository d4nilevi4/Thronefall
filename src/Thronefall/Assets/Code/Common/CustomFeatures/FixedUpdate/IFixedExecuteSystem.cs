using Entitas;

namespace Thronefall.Common
{
    public interface IFixedExecuteSystem : ISystem
    {
        void FixedExecute();
    }
}