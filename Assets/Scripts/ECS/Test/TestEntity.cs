using ECS.Emitter;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Test
{
    public class TestEntity : MonoBehaviour
    {
        public GameObject go;
        
        [Button]
        public void Test()
        {
            var contexts = Contexts.sharedInstance;
            var e = contexts.game.CreateEntity();

            var index = GameComponentsLookup.Health;
            e.AddHealth(100, 100, 100);
            Debug.Log($"health: {e.health.value}, prev: {e.health.prevValue}");
            
            e.ReplaceStat(index, 3);
            Debug.Log($"health: {e.health.value}, prev: {e.health.prevValue}");
        }
        
        [Button]
        public void Test2()
        {
        }
        
        [Button]
        public void Test3()
        {
            
        }
    }
}