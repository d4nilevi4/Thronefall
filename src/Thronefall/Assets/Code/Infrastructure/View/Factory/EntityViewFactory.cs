using UnityEngine;
using Zenject;

namespace Thronefall.Infrastructure
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _assetProvider = assetProvider;
            _instantiator = instantiator;
        }
        
        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            EntityBehaviour viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab,
                position: entity.WorldPosition,
                rotation: Quaternion.identity,
                parentTransform: null);
            
            view.SetEntity(entity);
            
            return view;
        }

        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            EntityBehaviour view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab,
                position: entity.WorldPosition,
                rotation: Quaternion.identity,
                parentTransform: null);
            
            view.SetEntity(entity);
            
            return view;
        }
    }
}