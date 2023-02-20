using ECS.System;

namespace ECS.Features
{
    public sealed class Time : Feature
    {
        public Time(Contexts contexts) : base("Time")
        {
            Add(new TimeSystem(contexts));
            Add(new TimerSystem(contexts));
        }
    }
}