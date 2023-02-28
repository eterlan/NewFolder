using System;
using ECS.Config;
using ECS.ExtensionMethod;
using ECS.Features;
using Entitas;
using UnityEditor;
using UnityEngine;
using Collision = ECS.Features.Collision;
using Time = ECS.Features.Time;

namespace ECS
{
    public class GameController : MonoBehaviour
    {
        public  ConfigManager ConfigManager;
        private Contexts      m_contexts;
        private Systems       m_systems;

        private void Awake()
        {
            m_contexts = Contexts.sharedInstance;
            m_contexts.Reset();
            ConfigManager.Init(m_contexts.config);

            m_contexts.SubscribeId();

            m_systems = CreateSystems(m_contexts);
            m_systems.Initialize();
        }

        private void Update()
        {
            m_systems.Execute();
            m_systems.Cleanup();
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Systems").Add(new ExecuteFirstGroup(contexts))
                                         .Add(new Time(contexts))
                                         .Add(new View(contexts))
                                         .Add(new Movement(contexts))
                                         .Add(new ExecuteMidGroup(contexts))
                                         .Add(new Chase(contexts))
                                         .Add(new Dmg(contexts))

                                         // !important, 应该先同步位置再添加物理, 不然会先跟原点的物体碰了之后再修改位置.
                                         .Add(new SyncToView(contexts))
                                         .Add(new Collision(contexts))
                                         
                                         .Add(new GameCleanupSystems(contexts))
                                         .Add(new InputCleanupSystems(contexts))
                                         .Add(new CleanUp(contexts));
        }

#if UNITY_EDITOR
        [InitializeOnEnterPlayMode]
        public static void ClearContext()
        {
            Contexts.sharedInstance = null;
        }
#endif
        
    }
    
    delegate int NumberChanger(int n);
    namespace DelegateAppl
    {
        class TestDelegate
        {
            static int num = 10;
            public static int AddNum(int p)
            {
                num += p;
                return num;
            }

            public static int MultNum(int q)
            {
                num *= q;
                return num;
            }
            public static int getNum()
            {
                return num;
            }

            static void Main(string[] args)
            {
                // 创建委托实例
                NumberChanger nc1 = AddNum;
                NumberChanger nc2 = new NumberChanger(MultNum);
                // 使用委托对象调用方法
                nc1(25);
                Console.WriteLine("Value of Num: {0}", getNum());
                nc2(5);
                Console.WriteLine("Value of Num: {0}", getNum());
                Console.ReadKey();
            }
        }
    }
}