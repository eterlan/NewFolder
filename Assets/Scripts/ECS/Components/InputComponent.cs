using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using EventType = Entitas.CodeGeneration.Attributes.EventType;

namespace ECS.Components
{
    [Input, Unique]
    public class LeftMouseComponent : IComponent
    {
    }

    [Input, Unique]
    public class RightMouseComponent : IComponent
    {
    }

    [Input, Unique]
    public class MousePosComponent : IComponent
    {
        public Vector2 posWS;
        public Vector2 posCS;
    }
    
    [Input]
    public class KeyDownComponent : IComponent
    {
    }

    [Input]
    public class KeyPressedComponent : IComponent
    {
    }

    [Input]
    public class KeyUpComponent : IComponent
    {
    }

    [Input]
    public class CollisionComponent : IComponent
    {
        public int a;
        public int b;
    }

    [Input, Unique]
    public class TimeComponent : IComponent
    {
        public float elapsedTime;
        public float deltaTime;
        public float timeScale;
    }

    [Input]
    public class Timer : IComponent
    {
        public float  startTime;
        public float  count;
        public float  elapsedTime;
        public float  duration;
        public Action callback;

        // 原本的持续时间翻倍
        public void SetDuration(float multiplier)
        {
            duration *= multiplier;
        }
        // 剩余时间翻倍
        public void SetRemainTime(float multiplier)
        {
            var extraTime = (duration - elapsedTime) * multiplier;
            duration += extraTime;
        }
    }
    
    [Input, Cleanup(cleanupMode: CleanupMode.DestroyEntity)]
    public class DmgComponent : IComponent
    {
        public int dmgID;
        public int entityID;
    }

    [Input, Cleanup(CleanupMode.DestroyEntity)]
    public class ScheduleDmgComponent : IComponent
    {
        public int dmgID;
        public int entityID;
    }

    [Input, Unique]
    public class TestDestroyComponent : IComponent
    {
        public int value;
    }

    [Input, Unique]
    public class SpawnCommand : IComponent
    {
        public int count;
        // SpawnType
    }

    [Input, Unique]
    public class ShootCommand : IComponent
    {
        
    }

    [Input, Unique]
    public class MoveCommand : IComponent
    {
        
    }
    
}