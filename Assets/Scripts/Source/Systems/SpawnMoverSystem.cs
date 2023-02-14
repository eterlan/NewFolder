using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpawnMoverSystem : ReactiveSystem<InputEntity>
{
    private readonly Contexts m_context;
    private float m_timer;
    public SpawnMoverSystem(Contexts context) : base(context.input)
    {
        m_context = context;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.LeftMouse, InputMatcher.MouseHold));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        var config = m_context.config.moverConfig.value;
        if (m_timer <= 0)
        {
            m_timer = config.generateInterval;
            Spawn();
        }
        else
            m_timer -= Time.deltaTime;

        void Spawn()
        {
            var e     = m_context.input.leftMouseEntity;
            var mover = m_context.game.CreateEntity();
            mover.isMover = true;
            var pos = e.mouseHold.position;
            mover.AddPosition(pos, pos);
            mover.AddDirection(Random.Range(0, 360));
        
            mover.AddMoveSpeed(config.moveSpeed);
            mover.AddSprite(config.sprite);
            mover.AddHealth(config.hp, config.hp);
        }
    }

}
