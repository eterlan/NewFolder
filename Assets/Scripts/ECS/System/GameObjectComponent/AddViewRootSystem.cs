using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class AddViewRootSystem :IInitializeSystem
    {
        private readonly GameContext m_context;
    
        // protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        // {
        //     return context.CreateCollector(GameMatcher.Sprite);
        // }
        //
        // protected override bool Filter(GameEntity entity)
        // {
        //     return entity.hasSprite && !entity.hasView;
        // }
        //
        // protected override void Execute(List<GameEntity> entities)
        // {
            // foreach (var e in entities)
            // {
            //     var go = new GameObject($"gameEntity: {e.id.value}");
            //     go.transform.SetParent(m_context.viewRoot.position, false);
            //     e.AddView(go);
            //     go.Link(e);
            // }
        // }

        public AddViewRootSystem(GameContext context)
        {
            m_context = context;
        }

        public void Initialize()
        {
            m_context.SetViewRoot(new GameObject("View Root").transform);
        }
    }
}