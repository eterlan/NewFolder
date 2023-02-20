//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity timeEntity { get { return GetGroup(InputMatcher.Time).GetSingleEntity(); } }
    public ECS.Components.TimeComponent time { get { return timeEntity.time; } }
    public bool hasTime { get { return timeEntity != null; } }

    public InputEntity SetTime(float newElapsedTime, float newDeltaTime, float newTimeScale) {
        if (hasTime) {
            throw new Entitas.EntitasException("Could not set Time!\n" + this + " already has an entity with ECS.Components.TimeComponent!",
                "You should check if the context already has a timeEntity before setting it or use context.ReplaceTime().");
        }
        var entity = CreateEntity();
        entity.AddTime(newElapsedTime, newDeltaTime, newTimeScale);
        return entity;
    }

    public void ReplaceTime(float newElapsedTime, float newDeltaTime, float newTimeScale) {
        var entity = timeEntity;
        if (entity == null) {
            entity = SetTime(newElapsedTime, newDeltaTime, newTimeScale);
        } else {
            entity.ReplaceTime(newElapsedTime, newDeltaTime, newTimeScale);
        }
    }

    public void RemoveTime() {
        timeEntity.Destroy();
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

    public ECS.Components.TimeComponent time { get { return (ECS.Components.TimeComponent)GetComponent(InputComponentsLookup.Time); } }
    public bool hasTime { get { return HasComponent(InputComponentsLookup.Time); } }

    public void AddTime(float newElapsedTime, float newDeltaTime, float newTimeScale) {
        var index = InputComponentsLookup.Time;
        var component = (ECS.Components.TimeComponent)CreateComponent(index, typeof(ECS.Components.TimeComponent));
        component.elapsedTime = newElapsedTime;
        component.deltaTime = newDeltaTime;
        component.timeScale = newTimeScale;
        AddComponent(index, component);
    }

    public void ReplaceTime(float newElapsedTime, float newDeltaTime, float newTimeScale) {
        var index = InputComponentsLookup.Time;
        var component = (ECS.Components.TimeComponent)CreateComponent(index, typeof(ECS.Components.TimeComponent));
        component.elapsedTime = newElapsedTime;
        component.deltaTime = newDeltaTime;
        component.timeScale = newTimeScale;
        ReplaceComponent(index, component);
    }

    public void RemoveTime() {
        RemoveComponent(InputComponentsLookup.Time);
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

    static Entitas.IMatcher<InputEntity> _matcherTime;

    public static Entitas.IMatcher<InputEntity> Time {
        get {
            if (_matcherTime == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Time);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTime = matcher;
            }

            return _matcherTime;
        }
    }
}