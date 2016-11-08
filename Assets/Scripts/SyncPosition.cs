using System.Collections.Generic;
using Entitas;

public class SyncPosition : IReactiveSystem, ISetPool
{
    private Pool _pool;
    private Group _synctargets;
    public void Execute(List<Entity> entities)
    {
        foreach (var entity in _synctargets.GetEntities())
        {
            if (entity.position.Value != entity.gameObject.GameObject.transform.position)
            {
                entity.ReplacePosition(entity.gameObject.GameObject.transform.position);
            }
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.CurrentTick.OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _synctargets = _pool.GetGroup(Matcher.AllOf(Matcher.Position, Matcher.GameObject));
    }
}