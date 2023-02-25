using ECS.System;

namespace ECS.Features
{
    public sealed class Collision : Feature
    {
        public Collision(Contexts contexts) : base("View Systems")
        {
            Add(new AddTriggerWarningSystem(contexts.game));
            Add(new AddDmgTriggerSystem(contexts));
            // Add(new CollisionSystem(contexts));
        }
    }
}
