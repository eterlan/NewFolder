using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;


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
public class HealthComponent : IComponent
{
    public int curValue;
    public int prevValue;
}

[Game]
public class CollisionComponent : IComponent
{
    public int a;
    public int b;
}