using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class LogMpSystem : ReactiveSystem<GameEntity>
{
    public LogMpSystem(IContext<GameEntity> context) : base(context)
    {
    }

    public LogMpSystem(ICollector<GameEntity> collector) : base(collector)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Mp);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasMp;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var mp = entity.mp;
            var result = mp switch
            {
                { curValue: 0, prevValue  : > 0 }                                 => "died",
                { curValue: > 0, prevValue: 0 }                                   => "revived",
                { curValue: > 0, prevValue: > 0 } when mp.curValue > mp.prevValue => "heal",
                { curValue: > 0, prevValue: > 0 } when mp.curValue < mp.prevValue => "hurt",
                _                                                                 => ""
            };
            if (result == "" && mp.curValue != mp.prevValue) Debug.LogWarning("这里有点奇怪");    
            var changeValue = Mathf.Abs(mp.prevValue - mp.curValue);
            Debug.Log($"curMp: {mp.curValue}, prevMp: {mp.prevValue}, result: {result}{changeValue}");
        }
    }
}