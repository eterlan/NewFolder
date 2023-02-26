using System.Collections.Generic;
using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace ECS.Components
{
    public interface IModifiableState : IComponent
    {
        public int            value     { get; set; }
        public int            prevValue { get; set; }
        
        public int            finalValue { get; set; }
    }

    public struct Modifier
    {
        public float        value;
        public ModifierType type;
    }

    public enum ModifierType
    {
        BaseAdd = 100,
        BaseMul = 200,
        FinalAdd = 300
    }

    [Game]
    public class Buff : IComponent
    {
        public List<int> buffIDList;
    }
    
    [Game]
    public class Equipment : IComponent
    {
        public List<int> equipmentIDList;
    }

    public class ModifyStatSystem : ReactiveSystem<GameEntity>
    {
        public ModifyStatSystem(IContext<GameEntity> context) : base(context)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AnyOf(GameMatcher.Buff));
        }

        protected override bool Filter(GameEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override void Execute(List<GameEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}