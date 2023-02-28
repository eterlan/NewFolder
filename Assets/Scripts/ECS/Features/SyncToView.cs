using ECS.System;

namespace ECS.Features
{
    public sealed class SyncToView : Feature
    {
        public SyncToView(Contexts contexts) : base(nameof(SyncToView))
        {
            Add(new SyncPositionToViewSystem(contexts.game));
            Add(new SyncDirectionToViewSystem(contexts.game));
        }
    }
}