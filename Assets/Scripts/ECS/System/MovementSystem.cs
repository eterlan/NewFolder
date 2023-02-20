using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class MovementSystem : IExecuteSystem, ICleanupSystem
    {
        private InputContext       m_context;
        private IGroup<GameEntity> m_moving, m_moveCompleted;
    
        public MovementSystem(Contexts contexts)
        {
            m_context       = contexts.input;
            m_moving        = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.MoveTarget, GameMatcher.MoveSpeed));
            m_moveCompleted = contexts.game.GetGroup(GameMatcher.MoveComplete);
            m_context       = contexts.input;
        }

        public void Execute()
        {
            var deltaTime = m_context.time.deltaTime;
            foreach (var e in m_moving.GetEntities())
            {
                var direction = e.moveTarget.target - e.position.value;
                e.ReplacePosition(e.position.value  + direction.normalized * e.moveSpeed.value * deltaTime, e.position.value);
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                e.ReplaceDirection(angle);

                var dist = direction.magnitude;
                if (dist < 0.5f)
                {
                    e.RemoveMoveTarget();
                    e.isMoveComplete = true;
                }
            }
        }

        public void Cleanup()
        {
            foreach (var e in m_moveCompleted.GetEntities())
            {
                e.isMoveComplete = false;
            }
        }
    }
}