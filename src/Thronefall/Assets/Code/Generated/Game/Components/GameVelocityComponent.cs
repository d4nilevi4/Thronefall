//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherVelocity;

    public static Entitas.IMatcher<GameEntity> Velocity {
        get {
            if (_matcherVelocity == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Velocity);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocity = matcher;
            }

            return _matcherVelocity;
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

    public Thronefall.Gameplay.PhysXMovement.Velocity velocity { get { return (Thronefall.Gameplay.PhysXMovement.Velocity)GetComponent(GameComponentsLookup.Velocity); } }
    public UnityEngine.Vector3 Velocity { get { return velocity.Value; } }
    public bool hasVelocity { get { return HasComponent(GameComponentsLookup.Velocity); } }

    public GameEntity AddVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (Thronefall.Gameplay.PhysXMovement.Velocity)CreateComponent(index, typeof(Thronefall.Gameplay.PhysXMovement.Velocity));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceVelocity(UnityEngine.Vector3 newValue) {
        var index = GameComponentsLookup.Velocity;
        var component = (Thronefall.Gameplay.PhysXMovement.Velocity)CreateComponent(index, typeof(Thronefall.Gameplay.PhysXMovement.Velocity));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveVelocity() {
        RemoveComponent(GameComponentsLookup.Velocity);
        return this;
    }
}
