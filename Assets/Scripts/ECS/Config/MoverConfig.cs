using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(MoverConfig), menuName = "GameConfig/MoverConfig")]
    public class MoverConfig : ScriptableObject
    {
        public AssetReferenceT<GameObject> prefabRef;
        public int                        hp        = 100;
        public int                        mp        = 100;
        public int                        moveSpeed = 5;

        public float spawnInterval = 0.2f;
    }

    [Unique, Config]
    public class MoverConfigComponent : IComponent
    {
        public MoverConfig                 config;
    }
}