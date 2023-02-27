using ECS.System;

namespace ECS.Features
{
    public sealed class Dmg : Feature
    {
        public Dmg(Contexts contexts) : base(nameof(Dmg))
        {
            Add(new ScheduleDmgSystem(contexts));
            Add(new ApplyDmgSystem(contexts)); 
        }
    }
}