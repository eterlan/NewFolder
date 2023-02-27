using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(WeaponConfigs), menuName = "GameConfig/WeaponConfig")]
    public class WeaponConfigs : ConfigBase<WeaponConfig>
    {
        public override void InitConfig(ConfigContext context)
        {
            context.SetWeaponConfigs(this);
        }
    }

    [Serializable]
    public class WeaponConfig : IIndex
    {
        public int                  id { get; private set; }
        public int                  dmgID;
        public AssetReferenceSprite spriteRef;
        public float                shootInterval = 0.3f;
        public float                velocity      = 10;
        public float                range         = 200;
    }

    [Unique, Config]
    public class WeaponConfigsComponent : IComponent
    {
        public WeaponConfigs value;
    }
}