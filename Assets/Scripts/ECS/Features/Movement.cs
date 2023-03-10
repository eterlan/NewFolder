using ECS.System;

namespace ECS.Features
{
    public sealed class Movement : Feature
    {
        public Movement(Contexts contexts) : base("Movement Systems")
        {
            Add(new MovementSystem(contexts));
        }
    }
}
