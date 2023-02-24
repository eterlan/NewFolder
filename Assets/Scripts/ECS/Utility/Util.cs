using System.Collections.Generic;
using ECS.Config;
using UnityEngine;

namespace ECS.Utility
{
    public static class Util
    {
        public static float elapsedTime => Contexts.sharedInstance.input.time.elapsedTime;

        public static float deltaTime => Contexts.sharedInstance.input.time.deltaTime;

        public static bool Duplicate<T>(IEnumerable<T> items)
        {
            var duplicate = false;
            var hashset   = new HashSet<T>();
            foreach (var item in items)
            {
                duplicate = !hashset.Add(item); 
                if (duplicate)
                {
                    Debug.LogWarning($"{items} duplicate");
                    break;
                }
            }

            return duplicate;
        }
    }
}
