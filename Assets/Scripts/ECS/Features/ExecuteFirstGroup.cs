using ECS.Converter;
using ECS.System;

namespace ECS.Features
{
    /// <summary>
    /// 事件或者标记应该发生在最开始, 这样能保证所有系统都能接受到这个事件
    /// 系统多了再细分, 先把预先执行的系统放一起
    /// </summary>
    public sealed class ExecuteFirstGroup : Feature
    {
        public ExecuteFirstGroup(Contexts contexts) : base(nameof(ExecuteFirstGroup))
        {
            Add(new InitMonoMapperSystem(contexts.game));
            Add(new PlayerInputHandler(contexts));
            Add(new MarkDeathSystem(contexts.game));
            Add(new DestroyOnMoveCompleteSystem(contexts.game));
        }
    }
}