//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity moverConfigEntity { get { return GetGroup(ConfigMatcher.MoverConfig).GetSingleEntity(); } }
    public ECS.Config.MoverConfigComponent moverConfig { get { return moverConfigEntity.moverConfig; } }
    public bool hasMoverConfig { get { return moverConfigEntity != null; } }

    public ConfigEntity SetMoverConfig(ECS.Config.MoverConfig newConfig) {
        if (hasMoverConfig) {
            throw new Entitas.EntitasException("Could not set MoverConfig!\n" + this + " already has an entity with ECS.Config.MoverConfigComponent!",
                "You should check if the context already has a moverConfigEntity before setting it or use context.ReplaceMoverConfig().");
        }
        var entity = CreateEntity();
        entity.AddMoverConfig(newConfig);
        return entity;
    }

    public void ReplaceMoverConfig(ECS.Config.MoverConfig newConfig) {
        var entity = moverConfigEntity;
        if (entity == null) {
            entity = SetMoverConfig(newConfig);
        } else {
            entity.ReplaceMoverConfig(newConfig);
        }
    }

    public void RemoveMoverConfig() {
        moverConfigEntity.Destroy();
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
public partial class ConfigEntity {

    public ECS.Config.MoverConfigComponent moverConfig { get { return (ECS.Config.MoverConfigComponent)GetComponent(ConfigComponentsLookup.MoverConfig); } }
    public bool hasMoverConfig { get { return HasComponent(ConfigComponentsLookup.MoverConfig); } }

    public void AddMoverConfig(ECS.Config.MoverConfig newConfig) {
        var index = ConfigComponentsLookup.MoverConfig;
        var component = (ECS.Config.MoverConfigComponent)CreateComponent(index, typeof(ECS.Config.MoverConfigComponent));
        component.config = newConfig;
        AddComponent(index, component);
    }

    public void ReplaceMoverConfig(ECS.Config.MoverConfig newConfig) {
        var index = ConfigComponentsLookup.MoverConfig;
        var component = (ECS.Config.MoverConfigComponent)CreateComponent(index, typeof(ECS.Config.MoverConfigComponent));
        component.config = newConfig;
        ReplaceComponent(index, component);
    }

    public void RemoveMoverConfig() {
        RemoveComponent(ConfigComponentsLookup.MoverConfig);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherMoverConfig;

    public static Entitas.IMatcher<ConfigEntity> MoverConfig {
        get {
            if (_matcherMoverConfig == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.MoverConfig);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherMoverConfig = matcher;
            }

            return _matcherMoverConfig;
        }
    }
}
