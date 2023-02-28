//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ECS.C.InvincibleComponent invincibleComponent = new ECS.C.InvincibleComponent();

    public bool isInvincible {
        get { return HasComponent(GameComponentsLookup.Invincible); }
        set {
            if (value != isInvincible) {
                var index = GameComponentsLookup.Invincible;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : invincibleComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherInvincible;

    public static Entitas.IMatcher<GameEntity> Invincible {
        get {
            if (_matcherInvincible == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Invincible);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInvincible = matcher;
            }

            return _matcherInvincible;
        }
    }
}
