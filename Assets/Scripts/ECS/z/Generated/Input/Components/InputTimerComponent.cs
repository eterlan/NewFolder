//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public ECS.C.Timer timer { get { return (ECS.C.Timer)GetComponent(InputComponentsLookup.Timer); } }
    public bool hasTimer { get { return HasComponent(InputComponentsLookup.Timer); } }

    public void AddTimer(float newStartTime, float newCount, float newElapsedTime, float newDuration, System.Action newCallback) {
        var index = InputComponentsLookup.Timer;
        var component = (ECS.C.Timer)CreateComponent(index, typeof(ECS.C.Timer));
        component.startTime = newStartTime;
        component.count = newCount;
        component.elapsedTime = newElapsedTime;
        component.duration = newDuration;
        component.callback = newCallback;
        AddComponent(index, component);
    }

    public void ReplaceTimer(float newStartTime, float newCount, float newElapsedTime, float newDuration, System.Action newCallback) {
        var index = InputComponentsLookup.Timer;
        var component = (ECS.C.Timer)CreateComponent(index, typeof(ECS.C.Timer));
        component.startTime = newStartTime;
        component.count = newCount;
        component.elapsedTime = newElapsedTime;
        component.duration = newDuration;
        component.callback = newCallback;
        ReplaceComponent(index, component);
    }

    public void RemoveTimer() {
        RemoveComponent(InputComponentsLookup.Timer);
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

    static Entitas.IMatcher<InputEntity> _matcherTimer;

    public static Entitas.IMatcher<InputEntity> Timer {
        get {
            if (_matcherTimer == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.Timer);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherTimer = matcher;
            }

            return _matcherTimer;
        }
    }
}
