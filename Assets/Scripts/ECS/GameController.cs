using System;
using ECS.Config;
using ECS.Features;
using ECS.System;
using ECS.UtilAndEx;
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
            m_contexts.config.SetMoverConfig(ConfigManager.moverConfig);
            m_contexts.config.SetPlayerConfig(ConfigManager.playerConfig, null);
            m_contexts.config.SetWeaponConfigs(ConfigManager.weaponConfig, new Sprite[] { });
            m_contexts.config.SetDmgConfigs(ConfigManager.dmgConfig, new GameObject[] { });

            m_contexts.SubscribeId();

            m_systems = CreateSystems(m_contexts);
            m_systems.Initialize();
        }

        delegate void Upd();
        private void Update()
        {
            m_systems.Execute();
            m_systems.Cleanup();
            var s = new Upd(Update);
        }

        private Systems CreateSystems(Contexts contexts)
        {
            return new Feature("Systems").Add(new Time(contexts))
                                         .Add(new View(contexts))
                                         .Add(new Movement(contexts))
                                         .Add(new Player(contexts))
                                         .Add(new Chase(contexts))
                                         .Add(new Collision(contexts))
                                         .Add(new Features.Test(contexts));
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