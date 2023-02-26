using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ECS.Config;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace ECS.System
{
    public class SpawnMoverSystem : ReactiveSystem<InputEntity>, IInitializeSystem, ITearDownSystem
    {
        private readonly Contexts                m_context;
        private          CancellationTokenSource m_cts;

        public SpawnMoverSystem(Contexts context) : base(context.input)
        {
            m_context = context;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.SpawnCommand.AddedOrRemoved());
        }

        protected override bool Filter(InputEntity entity)
        {
            return true; //entity.hasMouseDown;
        }

        protected override async void Execute(List<InputEntity> entities)
        {
            var moverConfigComponent = m_context.config.moverConfig;
            if (!moverConfigComponent.config.GetDefaultItem(out var config))
                return;
            var prefab = await config.prefabRef.OperationHandle.Convert<GameObject>();

            var hasSpawnCommand = m_context.input.hasSpawnCommand;
            if (hasSpawnCommand)
            {
                m_cts = new CancellationTokenSource();
                var canceled = false;
                while (!canceled)
                {
                    for (var i = 0; i < config.spawnAmountEachTime; i++) 
                        Spawn(prefab, config);
                    canceled = await UniTask.Delay(TimeSpan.FromSeconds(config.spawnInterval), cancellationToken: m_cts.Token).SuppressCancellationThrow();
                }
            }
            else
            {
                m_cts.Cancel();
                m_cts.Dispose();
            }
        }

        private void Spawn(GameObject prefab, MoverConfigItem config)
        {
            var mousePosWS = m_context.input.mousePos.posWS;

            var mover = m_context.game.CreateEntity();
            mover.isMover = true;
                
            var go = Object.Instantiate(prefab, mousePosWS, Quaternion.identity, m_context.game.viewRoot.position);
            go.Link(mover);
            mover.AddView(go);
                
            mover.AddPosition(mousePosWS, mousePosWS);
            mover.AddDirection(Random.Range(0, 360));
        
            mover.AddMoveSpeed(config.moveSpeed);
            // mover.AddSprite(config.sprite);
            mover.AddHealth(config.hp, config.hp, config.hp);
        }

        public void Initialize()
        {
            var moverConfigComponent = m_context.config.moverConfig;
            if (!moverConfigComponent.config.GetDefaultItem(out var item)) 
                return;
            item.prefabRef.LoadAssetAsync<GameObject>();
        }

        public void TearDown()
        {
            if (m_cts is { IsCancellationRequested: false })
            {
                m_cts.Cancel();
                m_cts.Dispose();    
            }
            var moverConfigComponent = m_context.config.moverConfig;
            
            moverConfigComponent.config.GetDefaultItem(out var item);
            item.prefabRef.ReleaseAsset();
        }
    }
}
