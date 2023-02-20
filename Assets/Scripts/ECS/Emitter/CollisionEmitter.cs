using Entitas.Unity;
using UnityEngine;

namespace ECS.Emitter
{
    public class CollisionEmitter : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            // #Q 靠layer还不够吗? 为什么扯上这兄弟? 再精确一点?
            // if (collision.gameObject.CompareTag())
            if (gameObject.GetEntityLink().entity is not GameEntity a || collision.gameObject.GetEntityLink().entity is not GameEntity b )
            {
                Debug.LogWarning("发生碰撞的a or b 不是GameEntity, 忽略");
                return;
            }
            // TODO 测试和
            Contexts.sharedInstance.input.CreateEntity().AddCollision(a.creationIndex, b.creationIndex);
        }
    }
}