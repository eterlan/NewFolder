using System.Collections.Generic;
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
    public class PositionComponent : IComponent
    {
        public Vector2 value;
        public Vector2 prevValue;
    }

    [Game]
    public class DirectionComponent : IComponent
    {
        public float value;
    }

    [Game, Cleanup(CleanupMode.RemoveComponent)]
    public class NeedViewComponent : IComponent
    {
    
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

    [Game]
    public class MonoMapper : IComponent
    {
        public Dictionary<string, Component> mapper = new ();
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