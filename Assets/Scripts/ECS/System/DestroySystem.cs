using ECS.Utility;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class DestroySystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> m_destroyGroup;

        public DestroySystem(Contexts contexts)
        {
            m_destroyGroup = contexts.game.GetGroup(GameMatcher.Destroy);
        }
        public void Cleanup()
        {
            foreach (var entity in m_destroyGroup.GetEntities())
            {
                entity.DestroyLinkedGameObject();
            }
        }
    }
}