using System.Collections.Generic;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class DestroySystem : ReactiveSystem<InputEntity>
    {
        public DestroySystem(IContext<InputEntity> context) : base(context)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TestDestroy.Removed());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            Debug.Log("component removed");
        }
    }
    
    public class CreateSystem : ReactiveSystem<InputEntity>
    {
        public CreateSystem(IContext<InputEntity> context) : base(context)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.TestDestroy.Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            Debug.Log("component added");
        }
    }
}