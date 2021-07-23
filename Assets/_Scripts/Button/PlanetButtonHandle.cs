using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetButtonHandle : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 startTouchPos;
    private Vector2 currentTouchPos;
    private Vector2 currentAtkPos;

    public void OnPointerDown(PointerEventData _eventData)
    {
        startTouchPos = _eventData.position;
        currentAtkPos = startTouchPos;
    }

    public void OnDrag(PointerEventData _eventData)
    {
        currentTouchPos = _eventData.position;
        Vector2 dirVec = currentTouchPos - startTouchPos;
        Vector2 normDirVec = dirVec.normalized;
        float distance = (currentTouchPos - startTouchPos).sqrMagnitude;

        if (distance > 50f)
        {
            if (0.9f < normDirVec.y && normDirVec.y <= 1f)
            {
                Debug.Log("점프");
            }
            else if (-1f <= normDirVec.y && normDirVec.y < -0.9f)
            {
                Debug.Log("슬라이드");
            }
        }
    }

    public void OnEndDrag(PointerEventData _eventData)
    {
        Debug.Log("원상태");
    }

    public void OnPointerUp(PointerEventData _eventData)
    {
        currentAtkPos = _eventData.position;
        Debug.Log(currentAtkPos);
        Debug.Log(startTouchPos);

        if((currentAtkPos - startTouchPos).sqrMagnitude < 1f)
        {
            Debug.Log("공격");
        }
    }
}
