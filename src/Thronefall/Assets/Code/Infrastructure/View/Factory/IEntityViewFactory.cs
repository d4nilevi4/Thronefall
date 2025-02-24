namespace Thronefall.Infrastructure
{
    public interface IEntityViewFactory
    {
        EntityBehaviour CreateViewForEntity(GameEntity entity);
        EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity);
    }
}