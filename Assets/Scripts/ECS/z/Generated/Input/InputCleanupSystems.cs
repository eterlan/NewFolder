//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.Roslyn.CodeGeneration.Plugins.CleanupSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class InputCleanupSystems : Feature {

    public InputCleanupSystems(Contexts contexts) {
        Add(new DestroyCollisionInputSystem(contexts));
        Add(new DestroyDmgInputSystem(contexts));
        Add(new DestroyScheduleDmgInputSystem(contexts));
    }
}
