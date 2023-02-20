using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(MoverConfig), menuName = "GameConfig/MoverConfig")]
    public class MoverConfig : ScriptableObject
    {
        public AssetReferenceSprite       sprite;
        public AssetReference             n;
        public AssetReferenceT<GameObject> s;
        public string                     prefabPath;
        public int                        hp        = 100;
        public int                        mp        = 100;
        public int                        moveSpeed = 5;

        public float generateInterval = 0.2f;
    }

    [Unique, Config]
    public class MoverConfigComponent : IComponent
    {
        public MoverConfig config;
        public GameObject  prefab;
    }
}