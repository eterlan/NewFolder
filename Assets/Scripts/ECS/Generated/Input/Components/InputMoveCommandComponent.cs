//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity moveCommandEntity { get { return GetGroup(InputMatcher.MoveCommand).GetSingleEntity(); } }

    public bool isMoveCommand {
        get { return moveCommandEntity != null; }
        set {
            var entity = moveCommandEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isMoveCommand = true;
                } else {
                    entity.Destroy();
                }
            }
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
public partial class InputEntity {

    static readonly ECS.Components.MoveCommand moveCommandComponent = new ECS.Components.MoveCommand();

    public bool isMoveCommand {
        get { return HasComponent(InputComponentsLookup.MoveCommand); }
        set {
            if (value != isMoveCommand) {
                var index = InputComponentsLookup.MoveCommand;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : moveCommandComponent;

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

    static Entitas.IMatcher<InputEntity> _matcherMoveCommand;

    public static Entitas.IMatcher<InputEntity> MoveCommand {
        get {
            if (_matcherMoveCommand == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.MoveCommand);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherMoveCommand = matcher;
            }

            return _matcherMoveCommand;
        }
    }
}
