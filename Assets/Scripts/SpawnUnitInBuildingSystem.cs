using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpawnUnitInBuildingSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            var prefab = entity.prefab.Value;
            var instance = Object.Instantiate(prefab.gameObject);
            instance.transform.position = entity.spawnPoint.Value;
            var components = instance.GetComponentsInChildren<IPlayerInitable>();
            foreach (var playerInitable in components)
            {
                playerInitable.Init(_pool, entity.player.Id);
                playerInitable.Entity.isAiControlled = entity.isAiControlled;
            }
            entity.isNeedSpawn = false;
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.NeedSpawn, Matcher.Building).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}