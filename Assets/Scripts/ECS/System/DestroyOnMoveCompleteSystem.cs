using System.Collections.Generic;
using Entitas;

namespace ECS.System
{
    public class DestroyOnMoveCompleteSystem : ReactiveSystem<GameEntity>
    {
        public DestroyOnMoveCompleteSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MoveComplete, GameMatcher.DestroyOnMoveComplete));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.isDestroy = true;
            }
        }
    }
}