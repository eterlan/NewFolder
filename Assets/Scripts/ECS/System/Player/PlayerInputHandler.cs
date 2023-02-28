using System;
using Entitas;
using UnityEngine;
using UnityEngine.InputSystem;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class PlayerInputHandler : IInitializeSystem, ITearDownSystem
    {
        private readonly Camera            m_camera;
        private readonly Contexts      m_contexts;
        private readonly PlayerInputConfig m_inputConfig;

        public PlayerInputHandler(Contexts contexts)
        {
            m_camera      = Camera.main;
            m_contexts    = contexts;
            m_inputConfig = new PlayerInputConfig();
            m_inputConfig.Enable();
        }
        public void Initialize()
        {
            m_inputConfig.GamePlay.Fire.performed      += OnFire;
            m_inputConfig.GamePlay.Fire.canceled       += OnFireCanceled;
            m_inputConfig.GamePlay.ClickMove.performed += OnClickMove;
            m_inputConfig.GamePlay.ClickMove.canceled  += OnClickMoveCancelled;
            m_inputConfig.GamePlay.Spawn.performed     += OnSpawn;
            m_inputConfig.GamePlay.Spawn.canceled      += OnSpawnCancelled;
            m_inputConfig.GamePlay.MousePos.performed  += OnMousePosChanged;
        }


        private void OnClickMove(InputAction.CallbackContext _) => m_contexts.input.isMoveCommand = true;
        private void OnClickMoveCancelled(InputAction.CallbackContext _) => m_contexts.input.isMoveCommand = false;
        private void OnFire(InputAction.CallbackContext _) => m_contexts.input.isShootCommand = true;
        private void OnFireCanceled(InputAction.CallbackContext _) => m_contexts.input.isShootCommand = false;
        private void OnSpawn(InputAction.CallbackContext _)
        {
            var spawnAmount = m_contexts.config.moverConfig.config.configItems[0].spawnAmountEachTime;
            m_contexts.input.SetSpawnCommand(spawnAmount);
        }

        private void OnSpawnCancelled(InputAction.CallbackContext _)
        {
            m_contexts.input.RemoveSpawnCommand();
        }

        private void OnMousePosChanged(InputAction.CallbackContext obj)
        {
            var mousePosCS = m_inputConfig.GamePlay.MousePos.ReadValue<Vector2>();
            var mousePosWS = m_camera.ScreenToWorldPoint(mousePosCS);
            m_contexts.input.ReplaceMousePos(mousePosWS, mousePosCS);
        }
        
        public void TearDown()
        {
            m_inputConfig.GamePlay.Fire.performed      -= OnFire;
            m_inputConfig.GamePlay.Fire.canceled       -= OnFireCanceled;
            m_inputConfig.GamePlay.ClickMove.performed -= OnClickMove;
            m_inputConfig.GamePlay.ClickMove.canceled  -= OnClickMoveCancelled;
            m_inputConfig.GamePlay.Spawn.performed     -= OnSpawn;
            m_inputConfig.GamePlay.Spawn.canceled      -= OnSpawnCancelled;
            m_inputConfig.GamePlay.MousePos.performed  -= OnMousePosChanged;
        }
        
    }
}
