//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherWeaponTypeId;

    public static Entitas.IMatcher<GameEntity> WeaponTypeId {
        get {
            if (_matcherWeaponTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.WeaponTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWeaponTypeId = matcher;
            }

            return _matcherWeaponTypeId;
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

    public Thronefall.Gameplay.Combat.WeaponTypeIdComponent weaponTypeId { get { return (Thronefall.Gameplay.Combat.WeaponTypeIdComponent)GetComponent(GameComponentsLookup.WeaponTypeId); } }
    public Thronefall.Gameplay.Combat.WeaponTypeId WeaponTypeId { get { return weaponTypeId.Value; } }
    public bool hasWeaponTypeId { get { return HasComponent(GameComponentsLookup.WeaponTypeId); } }

    public GameEntity AddWeaponTypeId(Thronefall.Gameplay.Combat.WeaponTypeId newValue) {
        var index = GameComponentsLookup.WeaponTypeId;
        var component = (Thronefall.Gameplay.Combat.WeaponTypeIdComponent)CreateComponent(index, typeof(Thronefall.Gameplay.Combat.WeaponTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceWeaponTypeId(Thronefall.Gameplay.Combat.WeaponTypeId newValue) {
        var index = GameComponentsLookup.WeaponTypeId;
        var component = (Thronefall.Gameplay.Combat.WeaponTypeIdComponent)CreateComponent(index, typeof(Thronefall.Gameplay.Combat.WeaponTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveWeaponTypeId() {
        RemoveComponent(GameComponentsLookup.WeaponTypeId);
        return this;
    }
}
