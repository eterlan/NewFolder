//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ECS.Components.WeaponComponent weapon { get { return (ECS.Components.WeaponComponent)GetComponent(GameComponentsLookup.Weapon); } }
    public bool hasWeapon { get { return HasComponent(GameComponentsLookup.Weapon); } }

    public void AddWeapon(int newId) {
        var index = GameComponentsLookup.Weapon;
        var component = (ECS.Components.WeaponComponent)CreateComponent(index, typeof(ECS.Components.WeaponComponent));
        component.id = newId;
        AddComponent(index, component);
    }

    public void ReplaceWeapon(int newId) {
        var index = GameComponentsLookup.Weapon;
        var component = (ECS.Components.WeaponComponent)CreateComponent(index, typeof(ECS.Components.WeaponComponent));
        component.id = newId;
        ReplaceComponent(index, component);
    }

    public void RemoveWeapon() {
        RemoveComponent(GameComponentsLookup.Weapon);
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

    static Entitas.IMatcher<GameEntity> _matcherWeapon;

    public static Entitas.IMatcher<GameEntity> Weapon {
        get {
            if (_matcherWeapon == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Weapon);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherWeapon = matcher;
            }

            return _matcherWeapon;
        }
    }
}
