using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class CommandMoveSystem : ReactiveSystem<InputEntity>
    {
        private InputContext       m_inputContext;
        private GameContext m_gameContext;
        public CommandMoveSystem(Contexts context) : base(context.input)
        {
            m_gameContext  = context.game;
            m_inputContext = context.input;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.AllOf(InputMatcher.KeyPressed, InputMatcher.MoveCommand));
        }

        // TODO
        protected override bool Filter(InputEntity entity)
        {
            Debug.Log("move");
            return true;
            //return entity.hasMouseHold;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            var mousePosWS = m_inputContext.mousePos.position;
            var player     = m_gameContext.tagPlayerEntity;
            player.ReplaceMoveTarget(mousePosWS);
        }
    }
}
