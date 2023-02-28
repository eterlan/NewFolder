using System;
using UnityEngine;

namespace ECS.Utility
{
    /// <summary>
    /// 等之后需要什么功能的时候重构一下
    /// </summary>
    public class CyLog
    {
        public static bool enable = true;

        public static void Log(object message)
        {
            LogInternal(message, LogType.Normal);
        }

        public static void LogWarn(object message)
        {
            LogInternal(message, LogType.Warn);
        }

        public static void LogError(object message)
        {
            LogInternal(message, LogType.Error);
        }

        private static void LogInternal(object message, LogType type)
        {
            if (!enable)
            {
                return;   
            }

            switch (type)
            {
                case LogType.Normal:
                    Debug.Log(message);
                    break;
                case LogType.Warn:
                    Debug.LogWarning(message);
                    break;
                case LogType.Error:
                    Debug.LogError(message);
                    break;
            }
            
        }
    }

    internal enum LogType
    {
        Normal = 0,
        Warn = 1,
        Error = 2,
    } 
}
