using Entitas;
using UnityEngine;

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

public class HealthComponent : IComponent
{
    public int curValue;
    public int prevValue;
}