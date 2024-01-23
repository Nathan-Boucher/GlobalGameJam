using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private InventoryInstance laser;

    private void Start()
    {
        _inventory.Initialize(laser);
    }
}
