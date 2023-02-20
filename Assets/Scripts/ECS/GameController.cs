using ECS.Config;
using ECS.Features;
using ECS.System;
using ECS.UtilAndEx;
using Entitas;
using UnityEditor;
using UnityEngine;
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
            m_contexts.config.SetMoverConfig(ConfigManager.moverConfig, null);
            m_contexts.config.SetPlayerConfig(ConfigManager.playerConfig, null);
            m_contexts.config.SetWeaponConfigs(ConfigManager.weaponConfig, new Sprite[] { });
            m_contexts.config.SetDmgConfigs(ConfigManager.dmgConfig, new GameObject[] { });

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
            return new Feature("Systems").Add(new Time(contexts))
                                         .Add(new View(contexts))
                                         .Add(new Movement(contexts))
                                         .Add(new Player(contexts))
                                         .Add(new Chase(contexts))
                                         .Add(new CollisionSystem(contexts))
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
}