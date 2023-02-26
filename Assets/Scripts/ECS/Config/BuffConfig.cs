using UnityEngine;
using System;
using System.Collections.Generic;
using DesperateDevs.Extensions;
using ECS.Components;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sirenix.OdinInspector;

namespace ECS.Config
{
    [CreateAssetMenu(fileName = nameof(BuffConfig), menuName = "GameConfig/Buff")]
    public class BuffConfig : ConfigBase<BuffItem>
    {
        public override void InitConfig(ConfigContext context)
        {
            context.SetBuffConfig(this);
        }
    }

    [Serializable]
    public class BuffItem : IIndex
    {
        [field: SerializeField]
        public int id { get; private set; }

        [ValueDropdown(nameof(GetAllModifiableState))]
        public string stateName;

        


        #region Odin
        private List<string> GetAllModifiableState()
        {
            var allStats = new List<string>();
            for (var i = 0; i < GameComponentsLookup.componentTypes.Length; i++)
            {
                var componentType = GameComponentsLookup.componentTypes[i];
                if (componentType.ImplementsInterface<IModifiableState>())
                {
                    allStats.Add(GameComponentsLookup.componentNames[i]);
                }
            }

            return allStats;
        }
        #endregion
    }

    [Unique, Config]
    public class BuffConfigComponent : IComponent
    {
        public BuffConfig config;
    }
}