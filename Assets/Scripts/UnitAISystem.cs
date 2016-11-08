using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class UnitAISystem : IReactiveSystem, ISetPool
{
    private Group _units;
    private Pool _pool;
    private Group _playerUnits;

    public void Execute(List<Entity> entities)
    {
        var notAttackedPlayerUnits = _playerUnits.GetEntities().ToList();
        
        foreach (var entity in _units.GetEntities())
        {
            if (!entity.hasTick)
            {
                entity.AddTick(_pool.currentTick.Current + Random.Range(100, 400));
                continue;
            }
            if (entity.tick.Value > _pool.currentTick.Current)
            {
                continue;
            }

            var unitGameobject = entity.gameObject.GameObject;
            Vector3 targetPosition;
            if (notAttackedPlayerUnits.Any())
            {
                var targetUnit = notAttackedPlayerUnits[Random.Range(0, notAttackedPlayerUnits.Count)];
                notAttackedPlayerUnits.Remove(targetUnit);
                targetPosition = targetUnit.gameObject.GameObject.transform.position;
            }
            else
            {
                targetPosition = unitGameobject.transform.position + new Vector3(Random.Range(-10f, 10), 0, Random.Range(-10f, 10f));
            }
            unitGameobject.transform.DOMove(targetPosition, 5f).SetSpeedBased(true);
            entity.RemoveTick();
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.CurrentTick.OnEntityAdded();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _units = pool.GetGroup(Matcher.AllOf(Matcher.Unit, Matcher.AiControlled));
        _playerUnits = pool.GetGroup(Matcher.AllOf(Matcher.Unit).NoneOf(Matcher.AiControlled));
    }
}