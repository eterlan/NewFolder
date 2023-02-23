using ECS.Emitter;
using ECS.UtilAndEx;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Test
{
    public class TestCollision : MonoBehaviour
    {
        public GameObject go;
        public GameObject rb; 
        
        [Button]
        public void Test()
        {
            var col = go.GetOrAddComponent<TriggerEmitter>();
            col.TriggerEnter += () =>
            {
                Debug.Log("Trigger");
            };
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