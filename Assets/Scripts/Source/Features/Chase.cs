public sealed class Chase : Feature
{
    public Chase(Contexts contexts) : base("Chase")
    {
        Add(new SpawnMoverSystem(contexts));
        Add(new ChaseTargetPlayer(contexts.game));
    }
}
