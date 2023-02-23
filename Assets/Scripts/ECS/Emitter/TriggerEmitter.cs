using System;
using ECS.UtilAndEx;
using UnityEngine;

namespace ECS.Emitter
{
    public class TriggerEmitter : MonoBehaviour
    {
        public event Action     TriggerEnter;
        public BoxCollider2D col2D;

        private void Awake()
        {
            col2D = gameObject.GetOrAddComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            //Debug.Log("VAR");
            TriggerEnter?.Invoke();
        }
    }
}