// using System.Collections.Generic;
// using Entitas;
//
// namespace ECS.System
// {
//     public class CommandMoveSystem : ReactiveSystem<InputEntity>
//     {
//         private IGroup<GameEntity> m_playerGroup;
//         public CommandMoveSystem(Contexts context) : base(context.input)
//         {
//             m_playerGroup = context.game.GetGroup(GameMatcher.TagPlayer);
//         }
//
//         protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
//         {
//             return context.CreateCollector(InputMatcher.AllOf(InputMatcher.RightMouse, InputMatcher.MouseHold));
//         }
//
//         // TODO
//         protected override bool Filter(InputEntity entity)
//         {
//             //return entity.hasMouseHold;
//         }
//
//         protected override void Execute(List<InputEntity> entities)
//         {
//             foreach (var e in entities)
//             {
//                 var movers = m_playerGroup.GetEntities();
//                 foreach (var player in movers)
//                 {
//                     player.ReplaceMoveTarget(e.mouseHold.position);   
//                 }
//             }
//         }
//     }
// }
