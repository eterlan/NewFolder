using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(DmgConfigs), menuName = "GameConfig/DmgConfigs")]
    public class DmgConfigs : ConfigBase<DmgConfig>
    {
    }

    [Serializable]
    public class DmgConfig : IIndex
    {
        [field:SerializeField]
        public int id { get; private set; }
        public string  vfxName;
        public DmgType type;
        public int     count;
        public float     interval;
        public int     dmgValue;
    }

    [Serializable]
    public enum DmgType
    {
        Bullet, 
        Fire
    }

    [Unique, Config]
    public class DmgConfigsComponent : IComponent
    {
        public DmgConfigs   configs;
        public GameObject[] prefabs;
    }
}