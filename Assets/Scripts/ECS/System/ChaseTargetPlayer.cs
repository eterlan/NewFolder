using System.Collections.Generic;
using Entitas;

namespace ECS.System
{
    public class ChaseTargetPlayer : ReactiveSystem<GameEntity>
    {
        private IGroup<GameEntity> m_mover;
        public ChaseTargetPlayer(IContext<GameEntity> context) : base(context)
        {
            m_mover = context.GetGroup(GameMatcher.AllOf(GameMatcher.Mover));
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.TagPlayer, GameMatcher.Position));
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isTagPlayer && entity.hasPosition;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var player in entities)
            {
                foreach (var e in m_mover.GetEntities())
                {
                    e.ReplaceMoveTarget(player.position.value);
                }
            }

        }
    }
}
