using System;
using System.Collections.Generic;
using ECS.Utility;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Config
{
    public abstract class ConfigBase : ScriptableObject
    {
        public abstract void InitConfig(ConfigContext context);
        public abstract void FillDictionary();
    }
    
    public abstract class ConfigBase<T> : ConfigBase where T : class, IIndex
    {
        [Searchable]
        [ValidateInput(nameof(ValidateConflict), "id冲突, 请换个id")]
        public List<T> configItems;

        public bool TryGetItem(int key, out T item)
        {
            if (!m_configItemDict.TryGetValue(key, out item))
            {
                Debug.LogWarning($"找不到id为: {key} 的 {typeof(T).Name}");
                return false;
            }

            return true;
        }

        public virtual bool GetDefaultItem(out T item)
        {
            item = default;
            if (configItems == null)
            {
                CyLog.LogError($"{this} 找不到默认配置, 请检查");
                return false;
            }

            if (configItems.Count == 0)
            {
                CyLog.LogError($"{this} 找不到默认配置, 请检查");
                return false;
            }

            item = configItems[0];
            return item != null;
        }
        
        private Dictionary<int, T> m_configItemDict;

        // 当游戏中的时候把所有配置加载到字典中
        // 添加一个按钮能重新加载到字典中

        private bool TryFillDictionary()
        {
            if (configItems == null)
                return false;

            m_configItemDict ??= new Dictionary<int, T>();
            m_configItemDict.Clear();
            foreach (var configItem in configItems)
            {
                if (!m_configItemDict.TryAdd(configItem.id, configItem))
                    return false;
            } 

            return true;
        }
        
        
        #region ODIN

        [Button("填充数据")]
        public override void FillDictionary()
        {
            var msg = "";
            msg = TryFillDictionary() ? $"配置表: {this} 成功加载{m_configItemDict.Count}条数据" 
                : $"加载失败, 请查看配置表: {this}是否有冲突id";

            throw new Exception();
            Debug.Log(msg); 
        }
        
        private bool ValidateConflict()
        {
            return TryFillDictionary(); 
        }

        #endregion
    }
}