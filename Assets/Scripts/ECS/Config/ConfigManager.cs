using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Config
{
    /// <summary>
    /// 统一的配置入口, 方便管理
    /// </summary>
    [CreateAssetMenu(fileName = nameof(ConfigManager), menuName = "GameConfig/ConfigManager")]
    public class ConfigManager : ScriptableObject
    {
        public PlayerConfig playerConfig;
        public MoverConfig  moverConfig;
        public DmgConfigs    dmgConfig;
        public WeaponConfigs weaponConfig;
    }
}