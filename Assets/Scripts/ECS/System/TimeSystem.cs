using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class TimeSystem : IExecuteSystem
    {
        private readonly InputContext m_context;
        public TimeSystem(Contexts context)
        {
            m_context = context.input;
            m_context.SetTime(0, 0, 1);
        }
        public void Execute()
        {
            var time = m_context.time;
            time.deltaTime   =  Time.deltaTime;
            time.elapsedTime += time.timeScale * time.deltaTime;
            // Debug.Log(time.elapsedTime + "asd");
        }
    }
}