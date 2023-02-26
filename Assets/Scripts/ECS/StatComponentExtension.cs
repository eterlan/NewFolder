using System;
using ECS.Components;

namespace ECS
{
    public static class StatComponentExtension
    {
        public static void ReplaceStat(this GameEntity entity, int index, int newValue)
        {
            var componentType = GameComponentsLookup.componentTypes[index];
            var newComponent  = (IModifiableState)entity.CreateComponent(index, componentType);
            newComponent.value     = newValue;
            newComponent.prevValue = ((IModifiableState)entity.GetComponent(index)).value;
            entity.ReplaceComponent(index, newComponent); 
        }
        public static void ReplaceStat(this GameEntity entity, string statName, int newValue)
        {
            var index         = Array.IndexOf(GameComponentsLookup.componentNames, statName);
            entity.ReplaceStat(index, newValue);
        }

        public static IModifiableState FindStatComponent(this GameEntity entity, int componentIndex)
        {
            return (IModifiableState)entity.GetComponent(componentIndex);
        }

        public static IModifiableState FindStatComponent(this GameEntity entity, string statName)
        {
            var index = Array.IndexOf(GameComponentsLookup.componentNames, statName);
            return FindStatComponent(entity, index);
        }

        public static IModifiableState FindStatComponent(this GameEntity entity, Type type)
        {
            var index = Array.IndexOf(GameComponentsLookup.componentTypes, type);
            return FindStatComponent(entity, index);
        }
        public static IModifiableState FindStatComponent<T>(this GameEntity entity)
        {
            return FindStatComponent(entity, typeof(T));
        }
    }
}