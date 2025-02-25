using UnityEngine;

namespace Thronefall.Gameplay.Hero
{
    public interface IHeroFactory
    {
        GameEntity CreateHero(Vector3 at);
    }
}