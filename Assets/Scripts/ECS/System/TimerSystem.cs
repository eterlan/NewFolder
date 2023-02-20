using ECS.Utility;
using Entitas;

namespace ECS.System
{
    public class TimerSystem : IExecuteSystem
    {
        private readonly IGroup<InputEntity> m_timerGroup;

        public TimerSystem(Contexts contexts)
        {
            m_timerGroup = contexts.input.GetGroup(InputMatcher.Timer);
        }
        public void Execute()
        {
            var delta = Util.deltaTime;
            foreach (var timerEntity in m_timerGroup.GetEntities())
            {
                var timer            = timerEntity.timer;
                timer.elapsedTime += delta;
                if (timer.elapsedTime < timer.duration) 
                    continue;
                
                timer.callback.Invoke();
                CyLog.Log(timer.callback.Target);
                timer.count--;
                if (timer.count == 0)
                    timerEntity.Destroy();
                else
                    timer.elapsedTime = 0;
            }
        }
    }
}
