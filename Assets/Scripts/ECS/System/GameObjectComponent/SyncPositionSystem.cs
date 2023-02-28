using System.Collections.Generic;
using Entitas;

namespace ECS.System
{
    public class SyncPositionToViewSystem : ReactiveSystem<GameEntity>
    {
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Position);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasPosition && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var position = entity.position;
                position.prevValue                        = position.value;
                entity.view.gameObject.transform.position = position.value;
            }
        }

        public SyncPositionToViewSystem(IContext<GameEntity> context) : base(context)
        {
        }
    }
}