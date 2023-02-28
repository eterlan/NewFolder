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
        public int                         id { get; private set; }
        public int                         dmgID;
        
        public AssetReferenceT<GameObject> weaponPrefab;

        // 子弹应该是放武器这还是伤害那? 感觉还是伤害那对一点, 咱们这个枪可以射不同的子弹嘛哈哈. 暂时不管 因为后面用特效做子弹
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