using UnityEngine;

namespace ECS.Utility
{
    public class CyLog
    {
        public static bool enable = true;

        public static void Log(object message)
        {
            if (!enable)
                return;
            Debug.Log(message);
        }
        
        public static void LogError(object message)
        {
            if (!enable)
                return;
            Debug.LogError(message);
        }
    }
}
