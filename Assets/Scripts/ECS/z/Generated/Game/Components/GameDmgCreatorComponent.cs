//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ECS.Components.DmgCreator dmgCreator { get { return (ECS.Components.DmgCreator)GetComponent(GameComponentsLookup.DmgCreator); } }
    public bool hasDmgCreator { get { return HasComponent(GameComponentsLookup.DmgCreator); } }

    public void AddDmgCreator(int newId) {
        var index = GameComponentsLookup.DmgCreator;
        var component = (ECS.Components.DmgCreator)CreateComponent(index, typeof(ECS.Components.DmgCreator));
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceDmgCreator(int newId) {
        var index = GameComponentsLookup.DmgCreator;
        var component = (ECS.Components.DmgCreator)CreateComponent(index, typeof(ECS.Components.DmgCreator));
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveDmgCreator() {
        RemoveComponent(GameComponentsLookup.DmgCreator);
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

    static Entitas.IMatcher<GameEntity> _matcherDmgCreator;

    public static Entitas.IMatcher<GameEntity> DmgCreator {
        get {
            if (_matcherDmgCreator == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.DmgCreator);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDmgCreator = matcher;
            }

            return _matcherDmgCreator;
        }
    }
}