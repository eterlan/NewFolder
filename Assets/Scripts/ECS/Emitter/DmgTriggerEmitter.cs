using UnityEngine;

namespace ECS.Emitter
{
    public class DmgTriggerEmitter : MonoBehaviour
    {
        private InputContext m_context;
        private void Start()
        {
            m_context = Contexts.sharedInstance.input;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!CompareTag("Dmg"))
            {
                return;
            }
            //m_context.CreateEntity().d
        }
    }
}
