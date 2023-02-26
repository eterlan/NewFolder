//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ECS.Components.Buff buff { get { return (ECS.Components.Buff)GetComponent(GameComponentsLookup.Buff); } }
    public bool hasBuff { get { return HasComponent(GameComponentsLookup.Buff); } }

    public void AddBuff(System.Collections.Generic.List<int> newBuffIDList) {
        var index = GameComponentsLookup.Buff;
        var component = (ECS.Components.Buff)CreateComponent(index, typeof(ECS.Components.Buff));
        component.buffIDList = newBuffIDList;
        AddComponent(index, component);
    }

    public void ReplaceBuff(System.Collections.Generic.List<int> newBuffIDList) {
        var index = GameComponentsLookup.Buff;
        var component = (ECS.Components.Buff)CreateComponent(index, typeof(ECS.Components.Buff));
        component.buffIDList = newBuffIDList;
        ReplaceComponent(index, component);
    }

    public void RemoveBuff() {
        RemoveComponent(GameComponentsLookup.Buff);
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

    static Entitas.IMatcher<GameEntity> _matcherBuff;

    public static Entitas.IMatcher<GameEntity> Buff {
        get {
            if (_matcherBuff == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Buff);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBuff = matcher;
            }

            return _matcherBuff;
        }
    }
}
