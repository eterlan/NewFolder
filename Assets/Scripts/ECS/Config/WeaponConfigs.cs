using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(WeaponConfigs), menuName = "GameConfig/WeaponConfig")]
    public class WeaponConfigs : ScriptableObject
    {
        public WeaponConfig[] config;
    }

    [Serializable]
    public class WeaponConfig
    {
        public int    id;
        public string spritePath;
        public float  shootInterval;
    }

    [Unique, Config]
    public class WeaponConfigsComponent : IComponent
    {
        public WeaponConfigs config;
        public Sprite[]      sprites;
    }
}