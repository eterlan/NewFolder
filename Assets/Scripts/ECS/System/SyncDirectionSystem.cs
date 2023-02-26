using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class RenderDirectionSystem : ReactiveSystem<GameEntity>
    {
        public RenderDirectionSystem(IContext<GameEntity> context) : base(context)
        {
        }

        public RenderDirectionSystem(ICollector<GameEntity> collector) : base(collector)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Direction);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasDirection && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                // TEST -90
                entity.view.gameObject.transform.rotation = Quaternion.AngleAxis(entity.direction.value, Vector3.forward);
            }
        }
    }
}