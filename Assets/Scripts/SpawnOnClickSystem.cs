using System.Collections.Generic;
using Entitas;

public class SpawnOnClickSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.player.Id != _pool.currentPlayer.Id)
            {
                continue;
            }
            entity.isNeedSpawn = true;
           
            entity.isClick = false;
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Building, Matcher.Click, Matcher.Prefab, Matcher.Player, Matcher.SpawnPoint).NoneOf(Matcher.AiControlled).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}