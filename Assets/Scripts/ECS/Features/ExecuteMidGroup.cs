using ECS.System;

namespace ECS.Features
{
    public sealed class ExecuteMidGroup : Feature
    {
        public ExecuteMidGroup(Contexts contexts) : base(nameof(ExecuteMidGroup))
        {
            Add(new PlayerMoveSystem(contexts));
            Add(new PlayerShootSystem(contexts));
        }
    }
}



