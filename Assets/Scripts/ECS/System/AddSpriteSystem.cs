using System.Collections.Generic;
using ECS.UtilAndEx;
using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class AddSpriteSystem : ReactiveSystem<GameEntity>
    {
        

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.Sprite);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasSprite && entity.hasView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var sr = entity.view.gameObject.GetOrAddComponent<SpriteRenderer>();
                sr.sprite = entity.sprite.sprite;
            }
        }

        public AddSpriteSystem(IContext<GameEntity> context) : base(context)
        {
        }
    }
}