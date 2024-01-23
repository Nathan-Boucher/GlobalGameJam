using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Inventory
{
    [SerializeField] private UI_Inventory _uiInventory = new UI_Inventory();
    [SerializeField] private List<InventoryInstance> listeObject = new List<InventoryInstance>();
    
    public void Initialize(InventoryInstance instance)
    {
        listeObject.Add(instance);
        ActualizeUI();
    }
    public void SetList(InventoryInstance newInstanceObject)
    {
        listeObject.Add(newInstanceObject);
    }
    
    public List<InventoryInstance> GetListe()
    {
        return listeObject;
    }

    public InventoryInstance GetInstance(int index)
    {
        return listeObject[index];
    }

    void ActualizeUI()
    {
        _uiInventory.Actualize(listeObject);
    }
}
