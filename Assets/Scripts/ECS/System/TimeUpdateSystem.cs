using Entitas;
using UnityEngine;

namespace ECS.System
{
    public class TimeUpdateSystem : IExecuteSystem
    {
        private readonly InputContext m_context;
        public TimeUpdateSystem(Contexts context)
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