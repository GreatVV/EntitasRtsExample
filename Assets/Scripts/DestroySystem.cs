using System.Collections.Generic;
using Entitas;

public class DestroySystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            _pool.DestroyEntity(entity);
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.Destroy.OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}