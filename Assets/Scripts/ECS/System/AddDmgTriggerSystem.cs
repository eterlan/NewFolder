using System.Collections.Generic;
using ECS.Emitter;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class AddDmgTriggerSystem : ReactiveSystem<GameEntity>
    {
        private ConfigContext m_configCtx;
        public AddDmgTriggerSystem(Contexts context) : base(context.game)
        {
            m_configCtx = context.config;
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
                var triggerEmitter = entity.view.gameObject.GetComponent<TriggerEmitter>();
                triggerEmitter.OnTriggerEnter += col => AddDmgTriggerHandler(entity, col);
            }
        }

        private void AddDmgTriggerHandler(GameEntity e, Collider2D col)
        {
            // TODO 应该提供一个base class 给configs查找配置用
            var configIndex = e.dmgCreator.id;
            var config      = m_configCtx.dmgConfigs.configs.configItems[configIndex];
             
        }
    }
}