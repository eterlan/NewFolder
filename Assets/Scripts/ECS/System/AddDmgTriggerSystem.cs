using System.Collections.Generic;
using ECS.Config;
using ECS.Emitter;
using ECS.UtilAndEx;
using ECS.Utility;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class AddDmgTriggerSystem : ReactiveSystem<GameEntity>
    {
        private Contexts m_ctx;
        public AddDmgTriggerSystem(Contexts context) : base(context.game)
        {
            m_ctx = context;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // 看起来有点点奇怪,
            // TEST 当先添加DmgCreator再添加Trigger的时候会怎样? 给两个系统断点看看执行顺序
            // TEST 上面再结合当系统的执行顺序是先AddDmg再AddTrigger会怎样? 共四种特殊情况, 再加一种正常顺序的情况. 分析总结测试结果.
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.DmgCreator, GameMatcher.Trigger, GameMatcher.View));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDmgCreator;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var triggerEmitter = entity.view.gameObject.GetOrAddComponent<TriggerEmitter>();
                triggerEmitter.OnTriggerEnter += col => AddDmgTriggerHandler(entity, col);
            }
        }

        private void AddDmgTriggerHandler(GameEntity selfEntity, Collider2D col)
        {
            var otherEntityLink = col.gameObject.GetEntityLink(); 
            if (otherEntityLink == null)
            {
                Debug.LogWarning($"Entity: {selfEntity.id.value}碰到了不是entity的{col.gameObject}");
                return;
            }

            if (otherEntityLink.entity is not GameEntity otherEntity)
            {
                Debug.LogWarning($"Entity: {otherEntityLink.entity.creationIndex}碰到了不是GameEntity的{col.gameObject}");
                return;
            }

            if (!otherEntity.isDamageable)
            {
                CyLog.Log($"Entity: {otherEntityLink.entity.creationIndex}碰到了无法受伤的{col.gameObject}");
                return;
            }

            // TODO 应该提供一个base class 给configs查找配置用
            var configIndex = selfEntity.dmgCreator.id;
            if (!m_ctx.config.dmgConfigs.configs.TryGetItem(configIndex, out var dmgConfig))
                return;
            // 还是把工作交给别人吧, 考虑到别的地方也会使用伤害, 把这个东西跟trigger绑定显得很奇怪
            // eventEntity.AddTimer(m_ctx.input.time.elapsedTime, dmgConfig.count, 0, dmgConfig.interval, () =>
            // {
            //     
            // });
            
            var eventEntity = m_ctx.input.CreateEntity();
            eventEntity.AddScheduleDmg(configIndex, otherEntity.creationIndex);
        }
    }
}