using System.Collections.Generic;
using ECS.Utility;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class DestroySystem : ReactiveSystem<GameEntity>
    {
        public DestroySystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.MoveComplete, GameMatcher.DestroyOnMoveComplete));
        }

        protected override bool Filter(GameEntity entity)
        {
            Debug.Log("true");
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            for (var i = 0; i < entities.Count; i++)
            {
                entities[i].DestroyLinkedGameObject();
            }
        }
    }
}