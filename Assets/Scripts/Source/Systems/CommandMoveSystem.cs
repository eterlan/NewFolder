using System.Collections.Generic;
using Entitas;

public class CommandMoveSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> m_moverGroup;
    public CommandMoveSystem(Contexts context) : base(context.input)
    {
        m_moverGroup = context.game.GetGroup(GameMatcher.Mover);
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseDown));
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasMouseDown;
    }

    protected override void Execute(List<InputEntity> entities)
    {
        foreach (var e in entities)
        {
            var movers = m_moverGroup.GetEntities();
            foreach (var mover in movers)
            {
                mover.ReplaceMoveTarget(e.mouseDown.position);   
            }
        }
    }
}
