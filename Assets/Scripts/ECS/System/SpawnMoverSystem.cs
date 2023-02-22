using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using ECS.Config;
using ECS.Utility;
using Entitas;
using Entitas.Unity;
using UnityEngine;
using UnityEngine.AddressableAssets;
using NotImplementedException = System.NotImplementedException;

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
            var config               = moverConfigComponent.config;
            var prefab = await moverConfigComponent.config.prefabRef.OperationHandle.Convert<GameObject>();

            var hasSpawnCommand = m_context.input.isSpawnCommand;
            if (hasSpawnCommand)
            {
                m_cts = new CancellationTokenSource();
                var canceled = false;
                while (!canceled)
                {
                    Spawn(prefab, config);
                    canceled = await UniTask.Delay(Mathf.RoundToInt(config.spawnInterval * 1000), cancellationToken: m_cts.Token).SuppressCancellationThrow();
                }
            }
            else
            {
                m_cts.Cancel();
                m_cts.Dispose();
            }
        }

        private void Spawn(GameObject prefab, MoverConfig config)
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
            mover.AddHealth(config.hp, config.hp);
        }

        public void Initialize()
        {
            var moverConfigComponent = m_context.config.moverConfig;
            moverConfigComponent.config.prefabRef.LoadAssetAsync<GameObject>();
        }

        public void TearDown()
        {
            if (m_cts is { IsCancellationRequested: false })
            {
                m_cts.Cancel();
                m_cts.Dispose();    
            }
            var moverConfigComponent = m_context.config.moverConfig;
            
            moverConfigComponent.config.prefabRef.ReleaseAsset();
        }
    }
}
