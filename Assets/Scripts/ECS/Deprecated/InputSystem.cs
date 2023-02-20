// using Entitas;
// using UnityEngine;
// using NotImplementedException = System.NotImplementedException;
//
// namespace ECS.System
// {
//     public class InputSystem : IInitializeSystem, IExecuteSystem
//     {
//         private readonly Camera            m_camera;
//         private readonly InputContext      m_contexts;
//         private          InputEntity       m_leftMouseEntity;
//         private          InputEntity       m_rightMouseEntity;
//         private const    int               LMB = 0, RMB = 1;
//         private          PlayerInputConfig m_inputConfig;
//
//         public InputSystem(Contexts contexts)
//         {
//             m_contexts                                =  contexts.input;
//             m_camera                                  =  Camera.main;
//             m_inputConfig                             =  new PlayerInputConfig();
//             
//         }
//         public void Initialize()
//         {
//             m_contexts.isLeftMouse  = true;
//             m_leftMouseEntity             = m_contexts.leftMouseEntity;
//             m_contexts.isRightMouse = true;
//             m_rightMouseEntity            = m_contexts.rightMouseEntity;
//         }
//
//         public void Execute()
//         {
//             Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
//             m_contexts.mousePos.position   = mousePos;
//             m_leftMouseEntity.isKeyDown    = Input.GetMouseButtonDown(LMB);
//             m_leftMouseEntity.isKeyPressed = Input.GetMouseButton(LMB);
//             m_leftMouseEntity.isKeyUp      = Input.GetMouseButton(LMB);
//
//             m_rightMouseEntity.isKeyDown    = Input.GetMouseButton(RMB);
//             m_rightMouseEntity.isKeyPressed = Input.GetMouseButton(RMB);
//             m_rightMouseEntity.isKeyUp      = Input.GetMouseButton(RMB);
//
//             //m_contexts.spawnCommandEntity.isKeyDown ;
//
//             void MapInput(InputEntity e, KeyCode keyCode)
//             {
//                 //e.isKeyDown = Input.GetButtonDown()
//             }
//
//             // TODO setting keymap
//             if (Input.GetKeyDown(KeyCode.T))
//             {
//                 m_contexts.isSpawnCommand = true;
//             }
//
//             if (Input.GetKeyUp(KeyCode.T))
//             {
//                 m_contexts.isSpawnCommand = false;
//             }
//
//             if (m_contexts.isSpawnCommand)
//             {
//                 Debug.Log("Pressed");
//             }
//         }
//
//         public void OnSpawnCommand(InputEntity entity)
//         {
//             Debug.Log("SpawnDown");
//         }
//
//         public void OnSpawnCommandRemoved(InputEntity entity)
//         {
//             Debug.Log("SpawnUp");
//         }
//     }
// }
