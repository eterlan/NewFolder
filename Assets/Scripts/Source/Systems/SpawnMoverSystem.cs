using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class SpawnMoverSystem : ReactiveSystem<InputEntity>, IInitializeSystem
{
    private readonly Contexts m_context;
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
        var config        = m_context.config.moverConfig.value;
        var timer = m_context.game.moverPrefabTimer;
        if (timer.value <= 0)
        {
            timer.value = config.generateInterval;
            Spawn();
        }
        else
            timer.value -= Time.deltaTime;

        void Spawn()
        {
            var mouse = m_context.input.leftMouseEntity;
            var pos   = mouse.mouseHold.position;

            var mover = m_context.game.CreateEntity();
            mover.isMover = true;
            var go = Object.Instantiate(config.prefab, pos, Quaternion.identity, m_context.game.viewRoot.position);
            go.Link(mover);
            mover.AddView(go);
            
            mover.AddPosition(pos, pos);
            mover.AddDirection(Random.Range(0, 360));
        
            mover.AddMoveSpeed(config.moveSpeed);
            // mover.AddSprite(config.sprite);
            mover.AddHealth(config.hp, config.hp);
        }
    }

    public void Initialize()
    {
        var config        = m_context.config.moverConfig.value;
        m_context.game.SetMoverPrefabTimer(config.generateInterval);
    }
}
