using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundClicker : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Pools.sharedInstance.pool.CreateEntity()
            .IsClick(true)
            .AddPosition(eventData.pointerCurrentRaycast.worldPosition);
    }
}