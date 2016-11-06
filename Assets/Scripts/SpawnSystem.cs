using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpawnSystem : IReactiveSystem, ISetPool
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

            var prefab = entity.prefab.Value;
            var instance = Object.Instantiate(prefab.gameObject);
            instance.transform.position = entity.spawnPoint.Value;
            var components = instance.GetComponentsInChildren<IPlayerInitable>();
            foreach (var playerInitable in components)
            {
                playerInitable.Init(_pool, entity.player.Id);
            }
            entity.isClick = false;
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Building, Matcher.Click, Matcher.Prefab, Matcher.Player, Matcher.SpawnPoint).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}