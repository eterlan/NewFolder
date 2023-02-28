using System;
using System.Collections.Generic;
using ECS.ExtensionMethod;
using Entitas;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;
using Object = UnityEngine.Object;

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

        public static GameObject CreateLinkedGameObject(this GameEntity e, string name = "")
        {
            var context = Contexts.sharedInstance.game;
            name = name.IsNullOrEmpty() ? e.id.value.ToString() : name;
            var go        = new GameObject(name);
            go.transform.SetParent(context.viewRoot.position, false);
            e.AddView(go);
            go.Link(e);
            return go;
        }

        public static void DestroyLinkedGameObject(this GameEntity e)
        {
            var go = e.view.gameObject;
            go.Unlink();
            e.Destroy();
            Object.Destroy(go);
        }

        public static void AddMonoMapper(this GameEntity owner, GameObject view)
        {
            var allTrs = view.GetComponentsInChildren<Transform>();
            foreach (var tr in allTrs)
            {
                if (tr.name.StartsWith("r_", StringComparison.OrdinalIgnoreCase))
                {
                    var strs = tr.name.Split('_');
                    if (strs.Length < 2)
                    {
                        CyLog.LogWarn($"{tr.gameObject}的命名不符合要求, 请重新命名");
                        continue;
                    }

                    var type = strs[1];
                    var name = strs[2];
                    if (type.Equals("tr", StringComparison.OrdinalIgnoreCase))
                    {
                        owner.monoMapper.mapper.Add(name.ToLower(), tr);
                    }
                }
            }
        }
    }
}
