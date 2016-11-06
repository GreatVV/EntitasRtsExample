using System.Collections.Generic;
using Entitas;

public class UnitSelectSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public void Execute(List<Entity> units)
    {
        foreach (var unit in units)
        {
            if (_pool.currentPlayer.Id == unit.player.Id)
            {
                unit.isSelect = true;
            }
            unit.isClick = false;
        }
    }

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.Click, Matcher.Unit, Matcher.Player).OnEntityAdded();
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}