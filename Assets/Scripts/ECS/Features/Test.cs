using ECS.System;

namespace ECS.Features
{
    public sealed class Test : Feature
    {
        public Test(Contexts ctx) : base("Test")
        {
            Add(new DestroySystem(ctx.game));
        }
    }
}