using System.Collections.Generic;
using ECS.Utility;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.C
{
    [Game]
    public class DmgCreator : IComponent
    {
        public int id;
    }

    [Game, Input] // contexts here
    public class IdComponent :IComponent {
        [PrimaryEntityIndex]
        public int value; // must be public in order for the index to be generated
    }

    [Game, Unique]
    public class TagPlayer : IComponent
    {
    
    }

    [Game]
    public class MpComponent : IComponent
    {
        public int curValue;
        public int prevValue;
    }

    [Game]
    public class Position : IComponent
    {
        public Vector2 value;
        public Vector2 prevValue;
    }

    [Game]
    public class Direction : IComponent
    {
        public float value;
    }


    [Game, Unique]
    public class ViewRoot : IComponent
    {
        public Transform position;
    }

    [Game]
    public class ViewComponent : IComponent
    {
        public GameObject gameObject;
    }

    [Game]
    public class SpriteComponent : IComponent
    {
        public Sprite sprite;
    }

    [Game]
    public class MoverComponent : IComponent
    {
    
    }

    [Game]
    public class MoveTargetComponent : IComponent
    {
        public Vector2 target;
    }

    [Game]
    public class MoveSpeedComponent : IComponent
    {
        public float value;
    }

    [Game]
    public class MoveCompleteComponent : IComponent
    {
    }

    [Game]
    public class HealthComponent : IModifiableState
    {
        // public int curValue;
        public int value      { get; set; }
        public int prevValue  { get; set; }
        public int finalValue { get; set; }
    }
    

    [Game]
    public class WeaponComponent : IComponent
    {
        public int     weaponID;
    }

    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public class TriggerComponent : IComponent
    {
        
    }

    [Game]
    public class InvincibleComponent : IComponent
    {
        
    }

    [Game]
    public class Name : IComponent
    {
        public string value;
    }

    [Game]
    public class DestroyOnMoveComplete : IComponent
    {
        
    }

    [Game]
    public class StateDeath : IComponent
    {
        
    }

    [Game]
    public class Destroy : IComponent
    {
        
    }

    /// <summary>
    /// <see cref="ECS.Converter.InitMonoMapperSystem"/>
    /// </summary>
    [Game]
    public class MonoMapper : IComponent
    {
        public Dictionary<string, Component> mapper = new ();

        public bool TryGetMonoComponent<T>(string key, out T component) where T : Component
        {
            component = default;
            key = key.ToLower();
            if (!mapper.TryGetValue(key, out var value))
            {
                CyLog.LogError($"字典中找不到对应的key:{key}");
                return false;
            }

            if (value is not T t)
            {
                CyLog.LogError($"字典中的key对应的值类型为{value.GetType()}而不是{typeof(T)}");
                return false;
            }

            component = t;
            return true;
        }
    }
    
    public class WeaponPos : IComponent
    {
        public Vector2 weaponCarryPoint;
    }

    public class PosFromViewGroup : IComponent
    {
        
    }
    // TODO
}