using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SpawnDamageParticleSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;

    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.health.Value < entity.previousHealth.Value)
            {
                var instance = Object.Instantiate(_pool.levelDescription.LevelDescription.DamageParticle);
                instance.transform.position = entity.position.Value;
                Object.Destroy(instance, 1f);
            }
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Health, Matcher.PreviousHealth, Matcher.Unit).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}