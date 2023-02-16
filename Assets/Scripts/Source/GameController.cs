using System;
using Entitas;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public  MoverConfig  moverConfig;
    public  PlayerConfig playerConfig;
    private Contexts     m_contexts;
    private Systems      m_systems;
    

    private void Awake()
    {
        m_contexts = Contexts.sharedInstance;
        m_contexts.Reset();
        m_contexts.config.SetMoverConfig(moverConfig);
        m_contexts.config.SetPlayerConfig(playerConfig);

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
        return new Feature("Systems").Add(new View(contexts))
                                     .Add(new Movement(contexts))
                                     .Add(new Player(contexts))
                                     .Add(new Chase(contexts))
                                     .Add(new CollisionSystem(contexts));
    }

    [InitializeOnEnterPlayMode]
    public static void ClearContext()
    {
        Contexts.sharedInstance = null;
    }
}