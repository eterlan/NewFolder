using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Config
{
    public class ConfigListBase<T> : ScriptableObject where T : IIndex
    {
        [Searchable]
        [ValidateInput(nameof(ValidateConflict), "id冲突, 请换个id")]
        public List<T> configItems;
        
        public bool TryGetItem(int id, out T item)
        {
            item = configItems.Find(i => i.id == id);
            if (item == null)
            {
                Debug.LogWarning($"找不到id为: {id} 的 {nameof(T)}");
                return false;
            }

            return true;
        }
        
        public Dictionary<int, T> dictionary;

        // 当游戏中的时候把所有配置加载到字典中
        // 添加一个按钮能重新加载到字典中
        private void OnEnable()
        {
            FillDictionary();
        }

        public bool TryFillDictionary()
        {
            var success = true;
            dictionary ??= new Dictionary<int, T>();
            dictionary.Clear();
            foreach (var configItem in configItems)
            {
                success = dictionary.TryAdd(configItem.id, configItem);
                if (!success)
                    break;
            }

            return success;
        }
        
        
        #region ODIN

        [Button("填充数据")]
        public void FillDictionary()
        {
            var msg = "";
            msg = TryFillDictionary() ? $"配置表: {name} 成功加载{dictionary.Count}条数据" 
                : $"加载失败, 请查看配置表: {name}是否有冲突id";
                
            Debug.Log(msg);
        }
        
        private bool ValidateConflict()
        {
            Debug.Log("validate");
            return TryFillDictionary(); 
        }

        #endregion
    }
}