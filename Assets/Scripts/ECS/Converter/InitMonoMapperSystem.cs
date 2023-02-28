using System;
using System.Collections.Generic;
using ECS.Utility;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.Converter
{
    /// <summary>
    /// 自动注册
    /// </summary>
    public class InitMonoMapperSystem : ReactiveSystem<GameEntity>
    {
        public InitMonoMapperSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.View, GameMatcher.MonoMapper));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = entity.view.gameObject;
                entity.AddMonoMapper(view);
            }
        }
    }
}