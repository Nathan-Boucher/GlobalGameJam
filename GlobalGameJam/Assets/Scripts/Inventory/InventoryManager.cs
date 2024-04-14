using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory _inventory = new Inventory();
    [SerializeField] private InventoryInstance _instance;

    private void Start()
    {
        _inventory.Initialize(_instance);
        PickUp.pickupItem += _inventory.SetList;
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }
}
