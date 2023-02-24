using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(WeaponConfigs), menuName = "GameConfig/WeaponConfig")]
    public class WeaponConfigs : ConfigListBase<WeaponConfig>
    {
    }

    [Serializable]
    public class WeaponConfig : IIndex
    {
        public string spritePath;
        public float  shootInterval;
        public int    id { get; private set; }
    }

    [Unique, Config]
    public class WeaponConfigsComponent : IComponent
    {
        public WeaponConfigs config;
        public Sprite[]      sprites;
    }
}