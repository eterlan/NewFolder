using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    // public class CommandMoveSystem : ReactiveSystem<InputEntity>, ICleanupSystem, IExecuteSystem
    // {
    //     private InputContext            m_inputContext;
    //     private GameContext             m_gameContext;
    //     private CancellationTokenSource m_cts;
    //
    //     public CommandMoveSystem(Contexts context) : base(context.input)
    //     {
    //         m_gameContext  = context.game;
    //         m_inputContext = context.input;
    //     }
    //
    //     protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    //     {
    //         return context.CreateCollector(InputMatcher.MoveCommand.AddedOrRemoved());
    //     }
    //
    //     // TODO
    //     protected override bool Filter(InputEntity entity)
    //     {
    //         return true;
    //         //return entity.hasMouseHold;
    //     }
    //
    //     protected override async void Execute(List<InputEntity> entities)
    //     {
    //         if (m_inputContext.isMoveCommand)
    //         {
    //             m_cts = new CancellationTokenSource();
    //             var isCancelled = false;
    //             while (!isCancelled)
    //             {
    //                 var mousePosWS = m_inputContext.mousePos.posWS;
    //                 var player     = m_gameContext.tagPlayerEntity;
    //                 player.ReplaceMoveTarget(mousePosWS);
    //                 isCancelled = await UniTask.NextFrame(m_cts.Token).SuppressCancellationThrow();
    //             }
    //         }
    //         else
    //         {
    //             m_cts.Cancel();
    //             m_cts.Dispose();
    //         }
    //     }
    //
    //     public void Cleanup()
    //     {
    //         if (m_cts is { IsCancellationRequested: false })
    //         {
    //             m_cts.Cancel();
    //             m_cts.Dispose();
    //         }
    //     }
    // }
    
    public class PlayerMoveSystem : IExecuteSystem
    {
        private readonly InputContext            m_inputContext;
        private readonly GameContext             m_gameContext;
        private          CancellationTokenSource m_cts;

        public PlayerMoveSystem(Contexts context)
        {
            m_gameContext  = context.game;
            m_inputContext = context.input;
        }
        
        public void Execute()
        {
            if (!m_inputContext.isMoveCommand)
                return;
            
            var mousePosWS = m_inputContext.mousePos.posWS;
            var player     = m_gameContext.tagPlayerEntity;
            player.ReplaceMoveTarget(mousePosWS);
        }
    }
}
