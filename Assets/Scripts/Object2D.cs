using System;
using UnityEngine;
using UnityEngine.Events;

public class Object2D : MonoBehaviour
{
    public ObjectManager objectManager;

    public Vector3 objectPosition;

    public bool isDragging = false;

    public void Update()
    {
        if (isDragging)
            objectPosition = GetMousePosition();
            this.transform.position = objectPosition;
            
    }

    private void OnMouseUpAsButton()
    {
        isDragging = !isDragging;

        if (!isDragging)
        {
            objectManager.ShowMenu();
        }
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }

}
