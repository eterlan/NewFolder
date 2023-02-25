using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.ResourceLocations;

namespace ECS.Config
{
    /// <summary>
    /// 统一的配置入口, 方便管理
    /// </summary>
    [CreateAssetMenu(fileName = nameof(ConfigManager), menuName = "GameConfig/ConfigManager")]
    public class ConfigManager : ScriptableObject
    {
        public AssetLabelReference label;
        [ShowInInspector]
        public List<ConfigBase<IIndex>> configs;

        private void OnEnable()
        {
            LoadAllConfigs();
        }

        [Button]
        public void LoadAllConfigs()
        {
            configs ??= new List<ConfigBase<IIndex>>();
            configs.Clear();
            var handles = Addressables.LoadAssetsAsync<ScriptableObject>(label, t =>
            {
                if (t is ConfigBase<IIndex> config)
                {
                    configs.Add(config);
                }
            });
            
            foreach (var config in configs)
            {
                config.FillDictionary();
            }
        }
    }
}