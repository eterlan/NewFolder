using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class CollisionSystem : ReactiveSystem<InputEntity>
{
    private Contexts m_context;
    public CollisionSystem(Contexts context) : base(context.input)
    {
        m_context = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.Collision);
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasCollision;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var collision = e.collision;
            var a         = m_context.game.GetEntityWithId(collision.a);
            var b         = m_context.game.GetEntityWithId(collision.b);
            Debug.Log($"{a.view.gameObject} 碰上了 {b.view.gameObject}");
        }
    }
}
