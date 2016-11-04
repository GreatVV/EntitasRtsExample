using Entitas;
using UnityEngine;

public class Swordsman : MonoBehaviour
{
    public void Init(Pool pool, int playerId)
    {
        Entity = pool.CreateEntity().IsUnit(true).AddPlayer(playerId).IsSword(true);
    }

    public Entity Entity { get; set; }
}