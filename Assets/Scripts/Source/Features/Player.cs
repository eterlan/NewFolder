public sealed class Player : Feature
{
    public Player(Contexts contexts) : base("Commander")
    {
        Add(new InputSystem(contexts));
        Add(new CommandMoveSystem(contexts));
    }
}
