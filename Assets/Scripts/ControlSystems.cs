using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ControlSystems : IReactiveSystem
{
    public void Execute(List<Entity> entities)
    {
        foreach (var entity in entities)
        {
            Debug.LogFormat("Click: {0}", entity.position.Value);
            entity.isDestroy = true;
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Click, Matcher.Position).OnEntityAdded(); }
    }
}