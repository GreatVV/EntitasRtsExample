using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public class Swordsman : MonoBehaviour, IPlayerInitable, IPointerClickHandler
{
    public float RegenerationRate = 10;
    public float StartHealth = 12;
    public float Damage = 6;
    public float AttackRadius = 6;

    public void Init(Pool pool, int playerId)
    {
        name = "Swordsman " + playerId;
        Entity = pool.CreateEntity().IsUnit(true).AddPlayer(playerId).IsSword(true).AddHealth(StartHealth).AddRegeneration(RegenerationRate).AddDamage(Damage).AddGameObject(gameObject).AddPosition(transform.position).AddAttackRadius(AttackRadius);
    }

    public Entity Entity { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        Entity.isClick = true;
    }
}