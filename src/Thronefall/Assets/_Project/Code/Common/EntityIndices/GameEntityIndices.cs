using System.Collections.Generic;
using Entitas;
using Thronefall.Gameplay.Combat;
using Thronefall.Gameplay.HitDetection;
using UnityEngine;
using Zenject;

namespace Thronefall.Common.EntityIndices
{
    public class GameEntityIndices : IInitializable
    {
        public const string WeaonHits = "WeaonHits";

        private readonly GameContext _game;

        public GameEntityIndices(GameContext game)
        {
            _game = game;
        }

        public void Initialize()
        {
            _game.AddEntityIndex(new EntityIndex<GameEntity, WeaponHitKey>(
                name: WeaonHits,
                _game.GetGroup(GameMatcher.AllOf(
                    GameMatcher.WeaponHit,
                    GameMatcher.Target,
                    GameMatcher.Causer)),
                getKey: GetTargetWeaponHitKey,
                new WeaponHitKeyEqualityComparer()));
        }

        private WeaponHitKey GetTargetWeaponHitKey(GameEntity entity, IComponent component)
        {
            return new WeaponHitKey((component as Causer)?.Value ?? entity.Causer);
        }
    }

    public static class GameContextIndicesExtensions
    {
        public static HashSet<GameEntity> TargetWeaponHits(this GameContext context, int weaponId)
        {
            return ((EntityIndex<GameEntity, WeaponHitKey>) context.GetEntityIndex(GameEntityIndices.WeaonHits))
                .GetEntities(new WeaponHitKey(weaponId));
        }
    }
}