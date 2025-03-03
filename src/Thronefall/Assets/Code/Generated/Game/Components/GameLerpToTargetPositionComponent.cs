//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherLerpToTargetPosition;

    public static Entitas.IMatcher<GameEntity> LerpToTargetPosition {
        get {
            if (_matcherLerpToTargetPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LerpToTargetPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLerpToTargetPosition = matcher;
            }

            return _matcherLerpToTargetPosition;
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

    static readonly Thronefall.Gameplay.Targeting.LerpToTargetPosition lerpToTargetPositionComponent = new Thronefall.Gameplay.Targeting.LerpToTargetPosition();

    public bool isLerpToTargetPosition {
        get { return HasComponent(GameComponentsLookup.LerpToTargetPosition); }
        set {
            if (value != isLerpToTargetPosition) {
                var index = GameComponentsLookup.LerpToTargetPosition;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : lerpToTargetPositionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
