//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVerifiedWeaponHit;

    public static Entitas.IMatcher<GameEntity> VerifiedWeaponHit {
        get {
            if (_matcherVerifiedWeaponHit == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VerifiedWeaponHit);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVerifiedWeaponHit = matcher;
            }

            return _matcherVerifiedWeaponHit;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly Thronefall.Gameplay.HitDetection.VerifiedWeaponHit verifiedWeaponHitComponent = new Thronefall.Gameplay.HitDetection.VerifiedWeaponHit();

    public bool isVerifiedWeaponHit {
        get { return HasComponent(GameComponentsLookup.VerifiedWeaponHit); }
        set {
            if (value != isVerifiedWeaponHit) {
                var index = GameComponentsLookup.VerifiedWeaponHit;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : verifiedWeaponHitComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
