namespace ECS.Utility
{
    public static class Util
    {
        public static float elapsedTime => Contexts.sharedInstance.input.time.elapsedTime;

        public static float deltaTime => Contexts.sharedInstance.input.time.deltaTime;
    }
}
