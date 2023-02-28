using System.Collections.Generic;
using Entitas;

namespace ECS.System
{
    public class ApplyDmgSystem : ReactiveSystem<InputEntity>
    {
        private Contexts m_contexts;
        
        public ApplyDmgSystem(Contexts context) : base(context.input)
        {
            m_contexts = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.Dmg);
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasDmg;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                var hurtE     = m_contexts.game.GetEntityWithId(entity.dmg.entityID);
                if (!m_contexts.config.dmgConfigs.configs.TryGetItem(entity.dmg.dmgID, out var dmgConfig))
                    continue;
                
                // TEST DMG
                var newValue = hurtE.health.value - dmgConfig.dmgValue;
                hurtE.ReplaceHealth(newValue, hurtE.health.value, newValue);
                
                // Play VFX and others 
                
                
            }    
        }
    }
}