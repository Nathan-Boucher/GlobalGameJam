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
    [SerializeField] private GameObject tele,chausson;
    void Start()
    {
        ClickInventory.selectItem += SelectionItem;
        PickUp.pickUpMug += doStart;
        Object.mugdrop += EnableObject;
        Object.mugdrop += doAfterStart;
        Object.telecommandeDrop += DogSpawn;
        Object.chaussonDrop += BreakDance;
        Cat.teleEnd += Chaussons;
    }

    void doStart()
    {
        _cat.Walk(DifferentsMoves[1].position);
    }

    void doAfterStart()
    {
        _cat.Walk(DifferentsMoves[3].position);
    }

    void DogSpawn()
    {
        player.colliderTV.enabled = false;
        tele.SetActive(true);
        _cat.Scared();
    }

    void BreakDance()
    {
        Debug.Log("ici je suis la ");
        _cat.BreakDance();
    }

    void Chaussons()
    {
        _cat.Walk(DifferentsMoves[5].position);
        chausson.GetComponent<PickUp>().enableToTake = true;
    }
    void SelectionItem(int index)
    {
        string nameIndex = "";
        nameIndex = _inventoryManager.GetInventory().GetListe()[index].objet.name;
        Debug.Log(nameIndex);
        
        if (nameIndex == "laser")
        {
            player.Laser();
        }
        else if (nameIndex == "Télécommande")
        {
            player.Telecommande();
            player.colliderTV.enabled = true;
        }
        else if(nameIndex == "Mug")
        {
            player.Mug();
        }
        else if (nameIndex == "chausson")
        {
            player.Chausson();
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
