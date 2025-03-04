//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherHitLayerMask;

    public static Entitas.IMatcher<GameEntity> HitLayerMask {
        get {
            if (_matcherHitLayerMask == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HitLayerMask);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHitLayerMask = matcher;
            }

            return _matcherHitLayerMask;
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

    public Thronefall.Gameplay.HitDetection.HitLayerMask hitLayerMask { get { return (Thronefall.Gameplay.HitDetection.HitLayerMask)GetComponent(GameComponentsLookup.HitLayerMask); } }
    public int HitLayerMask { get { return hitLayerMask.Value; } }
    public bool hasHitLayerMask { get { return HasComponent(GameComponentsLookup.HitLayerMask); } }

    public GameEntity AddHitLayerMask(int newValue) {
        var index = GameComponentsLookup.HitLayerMask;
        var component = (Thronefall.Gameplay.HitDetection.HitLayerMask)CreateComponent(index, typeof(Thronefall.Gameplay.HitDetection.HitLayerMask));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceHitLayerMask(int newValue) {
        var index = GameComponentsLookup.HitLayerMask;
        var component = (Thronefall.Gameplay.HitDetection.HitLayerMask)CreateComponent(index, typeof(Thronefall.Gameplay.HitDetection.HitLayerMask));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveHitLayerMask() {
        RemoveComponent(GameComponentsLookup.HitLayerMask);
        return this;
    }
}
