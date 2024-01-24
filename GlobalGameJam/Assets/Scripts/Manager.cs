using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private InventoryManager _inventoryManager;
    [SerializeField] private Player player;
    [SerializeField] private Cat _cat;
    [SerializeField] private List<Transform> DifferentsMoves;
    [SerializeField] private List<PickUp> allObjectsPickUp;
    void Start()
    {
        ClickInventory.selectItem += SelectionItem;
        PickUp.pickUpMug += doStart;
        Object.mugdrop += EnableObject;
        Object.mugdrop += doAfterStart;
    }

    void doStart()
    {
        _cat.Walk(DifferentsMoves[1].position);
    }

    void doAfterStart()
    {
        _cat.Walk(DifferentsMoves[3].position);
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
        else if(nameIndex == "Mug")
        {
            player.Mug();
        }

        
    }
    public void EnableObject()
    {
        for (int i = 0; i < allObjectsPickUp.Count; i++)
        {
            allObjectsPickUp[i].enableToTake = true;
        }
    }
}
