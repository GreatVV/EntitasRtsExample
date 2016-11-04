using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public class AxemanBaracks : MonoBehaviour, IPlayerInitable, IPointerClickHandler
{
    public GameObject AxemanPrefab;
    public Transform SpawnPoint;
    public void Init(Pool pool, int playerId)
    {
        Entity = pool.CreateEntity().IsBuilding(true).AddPlayer(playerId).IsAxe(true).AddPrefab(AxemanPrefab).AddSpawnPoint(SpawnPoint.position);
    }

    public Entity Entity { get; set; }
    public void OnPointerClick(PointerEventData eventData)
    {
        Entity.IsClick(true);
    }
}