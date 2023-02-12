using UnityEditor;
using UnityEngine;

namespace Tool
{
    public class TesterWindow : EditorWindow
    {
        [MenuItem("Tools/Cy/Tester #&T" )]
        private static void ShowWindow()
        {
            var window = GetWindow<TesterWindow>();
            window.titleContent = new GUIContent("Tester");
            window.Show();
        }

        private void OnGUI()
        {
            Buttons();
        }

        private void Buttons()
        {
            var testPressed  = GUILayout.Button("Test");
            var test2Pressed = GUILayout.Button("Test2");
            
            if (testPressed)
            {
                Debug.Log("12");
                var entities = Contexts.sharedInstance.game.GetGroup(GameMatcher.Mp);
                foreach (var e in entities)
                {
                    e.ReplaceMp(e.mp.curValue + 1, e.mp.curValue); 
                }    
            }

            if (test2Pressed)
            {
                Debug.Log("12");
            }
        }
    }
}
