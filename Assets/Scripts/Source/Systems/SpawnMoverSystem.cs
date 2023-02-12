using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpawnMoverSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts m_context;
    public SpawnMoverSystem(Contexts context) : base(context.input)
    {
        m_context = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var mover = m_context.game.CreateEntity();
            mover.isMover = true;
            mover.AddPosition(e.mouseDown.position, e.mouseDown.position);
            mover.AddDirection(Random.Range(0, 360));
            
            var config = m_context.config.moverConfig.value;
            mover.AddMoveSpeed(config.moveSpeed);
            mover.AddSprite(config.sprite);
            mover.AddHealth(config.hp, config.hp);
        }
    }
}
