using Entitas.Unity;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.Converter
{
    public class PlayerConverter : MonoBehaviour
    {
        [Button]
        public void Test()
        {
            Debug.Log("VARs");
        }
        private void Start()
        {
            var contexts = Contexts.sharedInstance;
            var e        = contexts.game.CreateEntity();
            e.isTagPlayer = true;
            var pos = Vector2.zero;
            e.AddPosition(pos, pos);
            e.AddDirection(Random.Range(0, 360));

            if (!contexts.config.playerConfig.config.GetDefaultItem(out var config))
                return;
            
            e.AddMoveSpeed(config.moveSpeed);
            // e.AddSprite(config.sprite);
            e.AddHealth(config.hp, config.hp, config.hp);
            e.AddView(gameObject);
            e.AddWeapon(0);
            gameObject.Link(e);
        }

        private void Update()
        {
            // Debug.Log("VARss");
        }
    }
}
