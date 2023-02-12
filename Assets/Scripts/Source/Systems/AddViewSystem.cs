using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class AddViewSystem : ReactiveSystem<GameEntity>
{
    private readonly Transform   m_viewContainer = new GameObject("Game Views").transform;
    private readonly GameContext m_context;



    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Sprite);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasSprite && !entity.hasView;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity e in entities)
        {
            GameObject go = new GameObject("Game View");
            go.transform.SetParent(m_viewContainer, false);
            e.AddView(go);
            go.Link(e);
        }
    }

    public AddViewSystem(IContext<GameEntity> context) : base(context)
    {
    }
}