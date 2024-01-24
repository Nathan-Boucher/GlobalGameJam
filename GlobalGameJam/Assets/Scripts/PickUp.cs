using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    public static event Action<InventoryInstance> pickupItem;
    public static event Action pickUpMug;
    public InventoryInstance item;
    public bool enableToTake;
    private void OnMouseDown()
    {
        if (enableToTake)
        {
            pickupItem.Invoke(item);
            if (item.objet.name == "Mug")
            {
                pickUpMug.Invoke();
            }
            Destroy(this.gameObject);
        }
        
    }
}
