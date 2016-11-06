using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public class Axeman : MonoBehaviour, IPlayerInitable, IPointerClickHandler
{
    public float StartHealth = 10;
    public float RegenerationRate = 5f;
    public float Damage = 8;

    public void Init(Pool pool, int playerId)
    {
        Entity = pool.CreateEntity().IsUnit(true).AddPlayer(playerId).IsAxe(true).AddHealth(StartHealth).AddRegeneration(RegenerationRate).AddDamage(Damage).AddGameObject(gameObject);
    }

    public Entity Entity { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        Entity.isClick = true;
    }
}