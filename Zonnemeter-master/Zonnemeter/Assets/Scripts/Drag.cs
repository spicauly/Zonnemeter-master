using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    float distance = 10;
    public bool isDragging;

    private void OnMouseDrag()
    {
        isDragging = true;
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }
}
