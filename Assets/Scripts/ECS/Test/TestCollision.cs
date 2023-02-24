using ECS.Emitter;
using ECS.UtilAndEx;
using Sirenix.OdinInspector;
using UnityEngine;

namespace ECS.Test
{
    public class TestCollision : MonoBehaviour
    {
        public GameObject go;
        
        [Button]
        public void Test()
        {
            var col = go.GetOrAddComponent<TriggerEmitter>();
            col.OnTriggerEnter += _ =>
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