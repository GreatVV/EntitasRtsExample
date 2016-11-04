using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwordsmanBaracks : MonoBehaviour, IPlayerInitable, IPointerClickHandler
{
    public GameObject SwordsmanPrefab;
    public Transform SpawnPoint;
    public void Init(Pool pool, int playerId)
    {
        Entity = pool.CreateEntity().IsBuilding(true).AddPlayer(playerId).IsSword(true).AddPrefab(SwordsmanPrefab).AddSpawnPoint(SpawnPoint.position);
    }

    public Entity Entity { get; set; }

    public void OnPointerClick(PointerEventData eventData)
    {
        Entity.IsClick(true);
    }
}