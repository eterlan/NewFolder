using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CollisionSystem : ReactiveSystem<GameEntity>
{
    public CollisionSystem(IContext<GameEntity> context) : base(context)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Collision);
    }
    

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            Debug.Log("col");
        }
    }
}
