using System;
using System.Collections.Generic;
using ECS.Emitter;
using ECS.UtilAndEx;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class AddTriggerWarningSystem : ReactiveSystem<GameEntity>
    {
        public AddTriggerWarningSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Trigger, GameMatcher.View));
        }

        protected override bool Filter(GameEntity entity)
        {
            Debug.Log("Trigger");
            var satisfied = entity.isTrigger && entity.hasView;
            if (!satisfied)
            {
                Debug.Log("not satisfied");
            }

            return satisfied;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var go = entity.view.gameObject;
                var triggerEmitter = go.GetOrAddComponent<TriggerEmitter>();
                triggerEmitter.OnTriggerEnter += col => TriggerEnterHandler(entity, col);
            }
        }

        private static void TriggerEnterHandler(GameEntity selfEntity, Collider2D otherCol)
        {
            var otherEntityLink = otherCol.gameObject.GetEntityLink(); 
            if (otherEntityLink == null)
            {
                Debug.LogWarning($"Entity: {selfEntity.id.value}碰到了不是entity的{otherCol}");
                return;
            }

            if (otherEntityLink.entity is not GameEntity otherEntity)
            {
                Debug.LogWarning($"Entity: {otherEntityLink.entity.creationIndex}碰到了不是GameEntity的{otherCol}");
                return;
            }
        }
    }
}