using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class InputHandler : IInitializeSystem, ITearDownSystem
    {
        private readonly Camera            m_camera;
        private readonly InputContext      m_contexts;
        private const    int               LMB = 0,           RMB = 1;
        private          PlayerInputConfig m_inputConfig;

        public InputHandler(Contexts contexts)
        {
            m_contexts                                =  contexts.input;
            m_camera                                  =  Camera.main;
            m_inputConfig                             =  new PlayerInputConfig();
            m_inputConfig.Enable();
        }
        public void Initialize()
        {
            m_contexts.isShootCommand                  =  true;
            m_contexts.isSpawnCommand                  =  true;
            m_contexts.isMoveCommand                   =  true;
            m_contexts.SetMousePos(Vector2.zero);
            
            m_inputConfig.GamePlay.Fire.performed += OnFirePerformed;
            m_inputConfig.GamePlay.Fire.canceled  += OnFireCanceled;
            
            m_inputConfig.GamePlay.ClickMove.performed += OnClickMovePerformed;
            m_inputConfig.GamePlay.ClickMove.performed += OnClickMoveCancelled;
            
            m_inputConfig.GamePlay.Spawn.performed += OnSpawnPerformed;
            m_inputConfig.GamePlay.Spawn.canceled  += OnSpawnCanceled;
            
            m_inputConfig.GamePlay.MousePos.performed += OnMousePosChanged;
        }

        private void OnMousePosChanged(InputAction.CallbackContext obj)
        {
            var mousePosCS = m_inputConfig.GamePlay.MousePos.ReadValue<Vector2>();
            var mousePosWS = m_camera.ScreenToWorldPoint(mousePosCS);
            m_contexts.mousePos.position = mousePosWS;
        }

        private void OnSpawnCanceled(InputAction.CallbackContext _) => m_contexts.spawnCommandEntity.isKeyPressed = false;
        private void OnSpawnPerformed(InputAction.CallbackContext _) => m_contexts.spawnCommandEntity.isKeyPressed = true;
        private void OnClickMoveCancelled(InputAction.CallbackContext _) => m_contexts.moveCommandEntity.isKeyPressed = false;
        private void OnClickMovePerformed(InputAction.CallbackContext _) => m_contexts.moveCommandEntity.isKeyPressed = true;
        private void OnFireCanceled(InputAction.CallbackContext _) => m_contexts.shootCommandEntity.isKeyPressed = false;
        private void OnFirePerformed(InputAction.CallbackContext _) => m_contexts.shootCommandEntity.isKeyPressed = true;

        public void TearDown()
        {
        }
        
    }
}
