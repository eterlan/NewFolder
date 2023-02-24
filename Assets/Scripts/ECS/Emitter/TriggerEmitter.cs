using System;
using ECS.UtilAndEx;
using UnityEngine;

namespace ECS.Emitter
{
    public class TriggerEmitter : MonoBehaviour
    {
        public event Action<Collider2D>     OnTriggerEnter;
        public BoxCollider2D col2D;

        private void Awake()
        {
            col2D           = gameObject.GetOrAddComponent<BoxCollider2D>();
            col2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //Debug.Log("VAR");
            OnTriggerEnter?.Invoke(col);
            
        }
    }
}