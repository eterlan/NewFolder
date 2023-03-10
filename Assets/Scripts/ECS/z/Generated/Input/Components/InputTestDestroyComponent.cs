//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity testDestroyEntity { get { return GetGroup(InputMatcher.TestDestroy).GetSingleEntity(); } }
    public ECS.C.TestDestroyComponent testDestroy { get { return testDestroyEntity.testDestroy; } }
    public bool hasTestDestroy { get { return testDestroyEntity != null; } }

    public InputEntity SetTestDestroy(int newValue) {
        if (hasTestDestroy) {
            throw new Entitas.EntitasException("Could not set TestDestroy!\n" + this + " already has an entity with ECS.C.TestDestroyComponent!",
                "You should check if the context already has a testDestroyEntity before setting it or use context.ReplaceTestDestroy().");
        }
        var entity = CreateEntity();
        entity.AddTestDestroy(newValue);
        return entity;
    }

    public void ReplaceTestDestroy(int newValue) {
        var entity = testDestroyEntity;
        if (entity == null) {
            entity = SetTestDestroy(newValue);
        } else {
            entity.ReplaceTestDestroy(newValue);
        }
    }

    public void RemoveTestDestroy() {
        testDestroyEntity.Destroy();
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

    public ECS.C.TestDestroyComponent testDestroy { get { return (ECS.C.TestDestroyComponent)GetComponent(InputComponentsLookup.TestDestroy); } }
    public bool hasTestDestroy { get { return HasComponent(InputComponentsLookup.TestDestroy); } }

    public void AddTestDestroy(int newValue) {
        var index = InputComponentsLookup.TestDestroy;
        var component = (ECS.C.TestDestroyComponent)CreateComponent(index, typeof(ECS.C.TestDestroyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTestDestroy(int newValue) {
        var index = InputComponentsLookup.TestDestroy;
        var component = (ECS.C.TestDestroyComponent)CreateComponent(index, typeof(ECS.C.TestDestroyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTestDestroy() {
        RemoveComponent(InputComponentsLookup.TestDestroy);
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

    static Entitas.IMatcher<InputEntity> _matcherTestDestroy;

    public static Entitas.IMatcher<InputEntity> TestDestroy {
        get {
            if (_matcherTestDestroy == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.TestDestroy);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTestDestroy = matcher;
            }

            return _matcherTestDestroy;
        }
    }
}
