using System.Collections.Generic;
using Entitas;

public class UnitSelectSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;
    private Group _selected;

    public void Execute(List<Entity> units)
    {
        foreach (var selectedUnit in _selected.GetEntities())
        {
            selectedUnit.isSelect = false;
        }

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
        _selected = pool.GetGroup(Matcher.AllOf(Matcher.Unit, Matcher.Select));
    }
}