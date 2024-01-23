using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Player player;
    void Start()
    {
        ClickInventory.selectItem += SelectionItem;
    }

    void SelectionItem(int index)
    {
        string nameIndex = "";
        nameIndex = _inventoryManager.GetInventory().GetListe()[index].objet.name;
        
        if (nameIndex == "laser")
        {
            player.Laser();
        }
        else if (nameIndex == "Télécommande")
        {
            player.Telecommande();
        }
    }
}
