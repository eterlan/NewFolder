using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "GameConfig/PlayerConfig")]
    public class PlayerConfig : ConfigBase<PlayerConfigItem>
    {
        
    }

    public class PlayerConfigItem : IIndex
    {
        [field: SerializeField]
        public int id { get; private set; }
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