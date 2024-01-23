using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    public static event Action<InventoryInstance> pickupItem; 
    public InventoryInstance item;
    private void OnMouseDown()
    {
        Debug.Log("Je prend cette item");
        pickupItem.Invoke(item);
        Destroy(this.gameObject);
    }
}
