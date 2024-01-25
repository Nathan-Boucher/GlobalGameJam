using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] private string nameObject;
    private Vector3 offset;
    private Collider2D Collider2D;

    public static event Action mugdrop; 
    public static event Action telecommandeDrop;
    public static event Action chaussonDrop;
    public static event Action herbeDrop;

    void Start()
    {
        Collider2D = GetComponent<Collider2D>();
    }
    private void OnMouseDown()
    {
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
            Debug.Log(hit.transform.tag);
            if (hit.transform.CompareTag("DropItem") && nameObject == "Mug" )
            {
                transform.position = hit.transform.position;
                mugdrop.Invoke();
            }
            else if(hit.transform.CompareTag("DropTelecommande") && nameObject == "telecommande")
            {
                transform.position = hit.transform.position;
                telecommandeDrop.Invoke();
                Destroy(gameObject);
            }
            else if (hit.transform.CompareTag("DropChausson") && nameObject == "chausson")
            {
                transform.position = hit.transform.position;
                chaussonDrop.Invoke();
                Destroy(gameObject);
            }
            else if (hit.transform.CompareTag("DropChausson") && nameObject == "Herbe")
            {
                herbeDrop.Invoke();
                Destroy(gameObject);
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
