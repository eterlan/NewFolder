using System;
using System.Collections.Generic;
using ECS.Utility;
using Entitas;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace ECS.Converter
{
    public class MonoMapper : ReactiveSystem<GameEntity>, ICleanupSystem
    {
        private          IGroup<GameEntity>        m_mapperGroup;
        private readonly IAllOfMatcher<GameEntity> m_matcher;

        public MonoMapper(IContext<GameEntity> context) : base(context)
        {
            m_matcher     = GameMatcher.AllOf(GameMatcher.View, GameMatcher.MonoMapper);
            m_mapperGroup = context.GetGroup(m_matcher);
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(m_matcher);
        }

        protected override bool Filter(GameEntity entity)
        {
            return true;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                var view = entity.view.gameObject;
                var allTrs         = view.GetComponentsInChildren<Transform>();
                foreach (var tr in allTrs)
                {
                    if (tr.name.StartsWith("r_", StringComparison.OrdinalIgnoreCase))
                    {
                        var strs = tr.name.Split('_');
                        if (strs.Length < 2)
                        {
                            CyLog.LogWarn($"{tr.gameObject}的命名不符合要求, 请重新命名");
                            continue;
                        }

                        var type = strs[1];
                        if (type.Equals("tr", StringComparison.OrdinalIgnoreCase))
                        {
                            entity.monoMapper.mapper.Add();
                        }
                    }
                }
            }
        }

        public void Cleanup()
        {
            
        }
    }
}