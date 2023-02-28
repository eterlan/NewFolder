using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class MarkDeathSystem : ReactiveSystem<GameEntity>
    {
        public MarkDeathSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Health).NoneOf(GameMatcher.StateDeath));
        }

        protected override bool Filter(GameEntity entity)
        {
            if (entity.isStateDeath)
            {
                Debug.Log("filter is death? shouldn't be here.");
            }
            return !entity.isStateDeath;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                // 先打个标签 让其他系统来处理死亡
                // entity.DestroyLinkedGameObject();
                if (entity.health.value <= 0)
                {
                    entity.isStateDeath = true;
                }
            }
        }
    }
}