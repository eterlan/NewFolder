public sealed class Commander : Feature
{
    public Commander(Contexts contexts) : base("Commander")
    {
        Add(new InputSystem(contexts));
        Add(new CommandMoveSystem(contexts));
        Add(new SpawnMoverSystem(contexts));
    }
}
