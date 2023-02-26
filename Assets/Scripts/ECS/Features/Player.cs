using ECS.System;

namespace ECS.Features
{
    public sealed class Player : Feature
    {
        public Player(Contexts contexts) : base("Commander")
        {
            Add(new InputHandler(contexts));
            Add(new CommandMoveSystem(contexts));
            Add(new ShootSystem(contexts));
        }
    }
}
