using System.Collections.Generic;
using Entitas;

public class AISystem : IReactiveSystem, ISetPool
{
    private Group _units;
    private Pool _pool;

    public void Execute(List<Entity> entities)
    {
        
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Unit, Matcher.Damage).OnEntityAdded();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _units = pool.GetGroup(Matcher.Unit);
    }
}