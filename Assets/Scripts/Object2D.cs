using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Object2D : MonoBehaviour
{
    public ObjectManager objectManager;

    public Vector3 objectPosition;

    public bool isDragging = false;
    public Guid id;
    public int typeIndex;

    private void Awake()
    {
        if (objectManager == null)
        {
            objectManager = FindObjectOfType<ObjectManager>();
        }
    }

    public void Update()
    {
        if (isDragging)
        {
            objectPosition = GetMousePosition();
            this.gameObject.transform.position = objectPosition;
        }
    }


    private void OnMouseDown()
    {
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        objectManager.ShowMenu();
    }

    private Vector3 GetMousePosition()
    {
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionInWorld.z = 0;
        return positionInWorld;
    }
}