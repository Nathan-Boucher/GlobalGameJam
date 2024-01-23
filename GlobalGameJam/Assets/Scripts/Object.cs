using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private bool find;
    
    private Vector3 offset;
    private Collider2D Collider2D;

    void Start()
    {
        Collider2D = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
        if (!find)
        {
            find = true;
        }
        offset = transform.position - MousePositionScreen();
    }

    private void OnMouseDrag()
    {
        transform.position = MousePositionScreen() + offset;
    }

    private void OnMouseUp()
    {
        Collider2D.enabled = false;
        var rayOrigin = Camera.main.transform.position;
        var rayDirection = MousePositionScreen() - Camera.main.transform.position;
        RaycastHit2D hit;
        if (hit = Physics2D.Raycast(rayOrigin, rayDirection))
        {
            if (hit.transform.CompareTag("DropItem"))
            {
                transform.position = hit.transform.position;
            }
        }

        Collider2D.enabled = true;
    }

    Vector3 MousePositionScreen()
    {
        var mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Camera.main.WorldToScreenPoint(transform.position).z;
        return Camera.main.ScreenToWorldPoint(mouseScreenPosition);
    }
        
}
