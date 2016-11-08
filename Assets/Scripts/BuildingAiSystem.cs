using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BuildingAiSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;
    private Group _buildings;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in _buildings.GetEntities())
        {
            if (!entity.hasTick)
            {
                entity.AddTick(_pool.currentTick.Current + Random.Range(60, 600));
                continue;
            }

            if (entity.tick.Value > _pool.currentTick.Current)
            {
                continue;
            }

            entity.isNeedSpawn = true;
            entity.RemoveTick();
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.CurrentTick.OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _buildings = pool.GetGroup(Matcher.AllOf(Matcher.Building, Matcher.AiControlled));
    }
}