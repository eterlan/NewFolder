using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class LogHealthSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> m_entities, m_noneMpEntities;
        public LogHealthSystem(Contexts contexts)
        {
            m_entities = contexts.game.GetGroup(GameMatcher.Health);
            var noneHpMatcher = Matcher<GameEntity>.AllOf(GameComponentsLookup.Health).NoneOf(GameComponentsLookup.Mp);
            m_noneMpEntities = contexts.game.GetGroup(noneHpMatcher);
        }
        public void Execute()
        {
            // foreach (var entity in m_entities)
            // {
            //     Debug.Log(entity.health.curValue);
            // }
            foreach (var entity in m_noneMpEntities.GetEntities())
            {
                Debug.Log($"no mp, hp: {entity.health}");
            }
        }
    }
}