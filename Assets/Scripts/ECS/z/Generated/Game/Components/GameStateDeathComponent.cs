//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ECS.C.StateDeath stateDeathComponent = new ECS.C.StateDeath();

    public bool isStateDeath {
        get { return HasComponent(GameComponentsLookup.StateDeath); }
        set {
            if (value != isStateDeath) {
                var index = GameComponentsLookup.StateDeath;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : stateDeathComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStateDeath;

    public static Entitas.IMatcher<GameEntity> StateDeath {
        get {
            if (_matcherStateDeath == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StateDeath);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStateDeath = matcher;
            }

            return _matcherStateDeath;
        }
    }
}