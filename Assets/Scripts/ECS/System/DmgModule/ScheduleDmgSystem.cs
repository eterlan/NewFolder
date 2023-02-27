using System.Collections.Generic;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class ScheduleDmgSystem : ReactiveSystem<InputEntity>
    {
        private Contexts            m_contexts;
        
        public ScheduleDmgSystem(Contexts contexts) : base(contexts.input)
        {
            m_contexts      = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ScheduleDmg);
        }

        protected override bool Filter(InputEntity entity)
        {
            Debug.Log("add");
            return entity.hasScheduleDmg;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                var dmgID = entity.scheduleDmg.dmgID;
                if (!m_contexts.config.dmgConfigs.configs.TryGetItem(dmgID, out var dmgConfig))
                    continue;
                var timerE = m_contexts.input.CreateEntity();

                CreateDmg();
                timerE.AddTimer(m_contexts.input.time.elapsedTime, dmgConfig.count, 0, dmgConfig.interval, CreateDmg);

                void CreateDmg()
                {
                    var dmgE = m_contexts.input.CreateEntity();
                    dmgE.AddDmg(dmgID, entity.scheduleDmg.entityID);
                }
            }
        }
    }
}