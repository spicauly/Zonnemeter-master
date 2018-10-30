using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;

        Debug.Log("OnBeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        Debug.Log("OnDrag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeingDragged = null;
        transform.position = startPosition;

        Debug.Log("OnEndDrag");
    }
}
