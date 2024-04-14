using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UI_Inventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> Slots;
    public void Actualize(List<InventoryInstance> allObjects)
    {
        for (int i = 0; i < allObjects.Count; i++)
        {
            Slots[i].GetComponent<Image>().sprite = allObjects[i].objet.sprite;
        }
    }

    public List<GameObject> GetSlots()
    {
        return Slots;
    }
}
