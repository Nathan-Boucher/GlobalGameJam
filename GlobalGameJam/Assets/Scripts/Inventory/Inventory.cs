using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<InventoryInstance> listeObject = new List<InventoryInstance>();


    public void Initialize(InventoryInstance instance)
    {
        listeObject.Add(instance);
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
}
