using UnityEngine;

namespace ECS.Utility
{
    public class CyLog
    {
        public static bool enable = false;

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
