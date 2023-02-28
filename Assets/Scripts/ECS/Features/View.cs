using ECS.System;

namespace ECS.Features
{
    public sealed class View : Feature
    {
        public View(Contexts contexts) : base("View Systems")
        {
            Add(new AddViewRootSystem(contexts.game));
            Add(new AddSpriteSystem(contexts.game));
            Add(new AddWeaponSystem(contexts));
        }
    }
}
