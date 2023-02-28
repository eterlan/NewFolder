using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using ECS.Converter;
using ECS.Utility;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.System
{
    public class AddWeaponSystem : ReactiveSystem<GameEntity>
    {
        private ConfigContext m_context;

        public AddWeaponSystem(Contexts contexts) : base(contexts.game)
        {
            m_context = contexts.config;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Weapon, GameMatcher.MonoMapper));
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {

                if (!m_context.weaponConfigs.value.TryGetItem(entity.weapon.weaponID, out var weaponConfig))
                    continue;

                var weaponPrefab = weaponConfig.weaponPrefab.LoadAssetAsync()
                                                     .WaitForCompletion();
                Debug.Log("VAR");

                entity.monoMapper.TryGetMonoComponent<Transform>(SpecialPoint.WeaponPos.ToString(), out var weaponCarryPoint);
                Debug.Log("VAR");

                var weaponView = Object.Instantiate(weaponPrefab, weaponCarryPoint);
                entity.AddMonoMapper(weaponView);
            }
        }
    }
}