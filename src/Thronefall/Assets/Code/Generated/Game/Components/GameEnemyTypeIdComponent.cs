//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnemyTypeId;

    public static Entitas.IMatcher<GameEntity> EnemyTypeId {
        get {
            if (_matcherEnemyTypeId == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyTypeId);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyTypeId = matcher;
            }

            return _matcherEnemyTypeId;
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

    public Thronefall.Gameplay.Enemies.EnemyTypeIdComponent enemyTypeId { get { return (Thronefall.Gameplay.Enemies.EnemyTypeIdComponent)GetComponent(GameComponentsLookup.EnemyTypeId); } }
    public Thronefall.Gameplay.Enemies.EnemyTypeId EnemyTypeId { get { return enemyTypeId.Value; } }
    public bool hasEnemyTypeId { get { return HasComponent(GameComponentsLookup.EnemyTypeId); } }

    public GameEntity AddEnemyTypeId(Thronefall.Gameplay.Enemies.EnemyTypeId newValue) {
        var index = GameComponentsLookup.EnemyTypeId;
        var component = (Thronefall.Gameplay.Enemies.EnemyTypeIdComponent)CreateComponent(index, typeof(Thronefall.Gameplay.Enemies.EnemyTypeIdComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceEnemyTypeId(Thronefall.Gameplay.Enemies.EnemyTypeId newValue) {
        var index = GameComponentsLookup.EnemyTypeId;
        var component = (Thronefall.Gameplay.Enemies.EnemyTypeIdComponent)CreateComponent(index, typeof(Thronefall.Gameplay.Enemies.EnemyTypeIdComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveEnemyTypeId() {
        RemoveComponent(GameComponentsLookup.EnemyTypeId);
        return this;
    }
}
