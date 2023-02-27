using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ECS.Utility;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class ShootSystem : ReactiveSystem<InputEntity>, ITearDownSystem
    {
        private readonly Contexts                m_contexts;
        private          CancellationTokenSource m_cts;

        public ShootSystem(Contexts contexts) : base(contexts.input)
        {
            m_contexts = contexts;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.ShootCommand.AddedOrRemoved());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true;
        }

        protected override async void Execute(List<InputEntity> entities)
        {
            if (m_contexts.input.isShootCommand)
            {
                var playerEntity = m_contexts.game.tagPlayerEntity;
                var weaponID     = playerEntity.weapon.weaponID;
                m_contexts.config.weaponConfigs.value.TryGetItem(weaponID, out var weaponInfo);
                
                m_cts = new CancellationTokenSource();
                var spriteRef = weaponInfo.spriteRef;
                Sprite sprite    = null;

                sprite = spriteRef.IsDone ? (Sprite)weaponInfo.spriteRef.editorAsset 
                    : await weaponInfo.spriteRef.LoadAssetAsync();


                while (m_contexts.input.isShootCommand)
                {
                    var playerPos       = playerEntity.position.value;
                    var direction = (m_contexts.input.mousePos.posWS - playerEntity.position.value).normalized;
                    var targetPos    = direction * weaponInfo.range + playerPos;
                    var e         = m_contexts.game.CreateEntity();
                    e.AddSprite(sprite);
                    e.AddPosition(playerPos, playerPos);
                    e.AddMoveTarget(targetPos);
                    e.AddMoveSpeed(weaponInfo.velocity);
                    e.isTrigger = true;
                    e.AddDmgCreator(weaponInfo.dmgID);
                    e.CreateLinkedGameObject();
                    e.isDestroyOnMoveComplete = true;

                    var interval = Mathf.RoundToInt(weaponInfo.shootInterval * 1000);
                    await UniTask.Delay(interval);
                }    
            }
            else
            {
                m_cts.Cancel();
                m_cts.Dispose();
            }
            
        }

        public void TearDown()
        {
            if (m_cts is not { IsCancellationRequested: false }) return;
            m_cts.Cancel();
            m_cts.Dispose();
        }
    }
}