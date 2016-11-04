using Entitas;
using UnityEngine;

public class Axeman : MonoBehaviour, IPlayerInitable
{
    public void Init(Pool pool, int playerId)
    {
        Entity = pool.CreateEntity().IsUnit(true).AddPlayer(playerId).IsAxe(true);
    }

    public Entity Entity { get; set; }
}