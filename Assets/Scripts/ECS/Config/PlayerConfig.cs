using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "GameConfig/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public string spritePath;
        public int    hp        = 100;
        public int    mp        = 100;
        public int    moveSpeed = 8;
    }

    [Unique, Config]
    public class PlayerConfigComponent : IComponent
    {
        public PlayerConfig config;
        public Sprite       sprite;
    }
}