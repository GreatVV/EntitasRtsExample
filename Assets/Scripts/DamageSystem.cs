using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class DamageSystem : IReactiveSystem, ISetPool
{
    private Pool _pool;
    private Group _attackable;

    public void Execute(List<Entity> entities)
    {
        var attackable = _attackable.GetEntities();
        
        foreach (var entity in entities)
        {
            var currentAttacker = entity;
            var targets = attackable.Where(x => x.player.Id != currentAttacker.player.Id && Vector3.Distance(x.position.Value, currentAttacker.position.Value) < currentAttacker.attackRadius.Value);
            foreach (var target in targets)
            {
                target.ReplacePreviousHealth(target.health.Value);
                var newHealth = target.health.Value - entity.damage.Value;
                Debug.LogFormat("attack: {0} to {1} new health {2}", currentAttacker, target, newHealth);
                target.ReplaceHealth(newHealth);
            }
        }
    }

    public TriggerOnEvent trigger
    {
        get { return Matcher.AllOf(Matcher.Unit, Matcher.Damage, Matcher.AttackRadius, Matcher.Position, Matcher.Player).OnEntityAdded(); }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _attackable = _pool.GetGroup(Matcher.AllOf(Matcher.Health, Matcher.Player, Matcher.Position));
    }
}