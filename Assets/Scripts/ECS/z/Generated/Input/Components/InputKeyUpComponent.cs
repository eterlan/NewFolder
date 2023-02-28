//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly ECS.C.KeyUpComponent keyUpComponent = new ECS.C.KeyUpComponent();

    public bool isKeyUp {
        get { return HasComponent(InputComponentsLookup.KeyUp); }
        set {
            if (value != isKeyUp) {
                var index = InputComponentsLookup.KeyUp;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : keyUpComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherKeyUp;

    public static Entitas.IMatcher<InputEntity> KeyUp {
        get {
            if (_matcherKeyUp == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.KeyUp);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherKeyUp = matcher;
            }

            return _matcherKeyUp;
        }
    }
}
