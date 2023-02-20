using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(DmgConfigs), menuName = "GameConfig/DmgConfigs")]
    public class DmgConfigs : ScriptableObject
    {
        public DmgConfig[] configs;
    }

    [Serializable]
    public class DmgConfig
    {
        public int     id;
        public string  vfxName;
        public DmgType type;
        public int     total;
        public int     interval;
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