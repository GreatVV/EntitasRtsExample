using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class DeathSystem : IReactiveSystem
{
    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            if (entity.health.Value < 0)
            {
                Debug.Log("Death to " + entity);
                Object.Destroy(entity.gameObject.GameObject.gameObject);
                entity.isDestroy = true;
            }
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Health, Matcher.GameObject).OnEntityAdded(); }
    }
}