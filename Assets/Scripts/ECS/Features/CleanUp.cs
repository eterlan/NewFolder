using ECS.System;

namespace ECS.Features
{
    public sealed class CleanUp : Feature
    {
        public CleanUp(Contexts contexts) : base(nameof(CleanUp))
        {
            
            
            // 最后才摧毁死亡的entity
            Add(new DestroySystem(contexts));
        }
    }
}