using Sirenix.OdinInspector;
using UnityEngine;

namespace Test
{
    public class Tester : MonoBehaviour
    {
        [Button]
        public void Test()
        {
            var entities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Mp);
            foreach (var e in entities)
            {
                e.mp.curValue += 1;
            }
        }

        [Button]
        public void TestTemp()
        {
            Debug.Log("13");
            var entities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Mp);
            foreach (var e in entities)
            {
                e.ReplaceMp(e.mp.curValue - 1, e.mp.curValue); 
            }
        }
    }
}