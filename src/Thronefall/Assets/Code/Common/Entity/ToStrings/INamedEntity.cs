using Entitas;

namespace Thronefall.Common.Entity
{
    public interface INamedEntity : IEntity
    {
        string EntityName(IComponent[] components);
        string BaseToString();
    }
}