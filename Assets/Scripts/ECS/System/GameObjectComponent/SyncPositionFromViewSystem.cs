using Entitas;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class SyncPositionFromViewSystem : IExecuteSystem
    {
        private IGroup<GameEntity> m_posFromViewGroup;

        public SyncPositionFromViewSystem(Contexts contexts)
        {
            //m_posFromViewGroup = contexts.game.posFromViewGroup;
        }
        public void Execute()
        {
            
        }
    }
}