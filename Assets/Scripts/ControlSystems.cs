using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public class ControlSystems : IReactiveSystem, ISetPool
{
    private Pool _pool;
    private Group _selectedUnits;

    public void Execute(List<Entity> entities)
    {
        var units = _selectedUnits.GetEntities();

        foreach (var click in entities)
        {
            Debug.LogFormat("Click: {0}", click.position.Value);
            foreach (var unit in units)
            {
                var transform = unit.gameObject.GameObject.transform;
                transform.DOKill();
                transform.DOMove(new Vector3(click.position.Value.x, transform.position.y, click.position.Value.z), 10).SetSpeedBased(true);
            }
            click.isDestroy = true;
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Click, Matcher.Position).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _selectedUnits = _pool.GetGroup(Matcher.AllOf(Matcher.Unit, Matcher.Select, Matcher.GameObject));
    }
}