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
        GetComponent<AudioSource>().Play();
        ClickInventory.selectItem += SelectionItem;
        PickUp.pickUpMug += doStart;
        Object.mugdrop += EnableObject;
        Object.mugdrop += doAfterStart;
        Object.telecommandeDrop += DogSpawn;
        Object.chaussonDrop += BreakDance;
        Object.herbeDrop += Krokmou;
        Cat.teleEnd += Chaussons;
        Cat.sulktime += EnableHerbe;
    }

    void doStart()
    {
        _cat.Walk(DifferentsMoves[1].position);
    }

    void doAfterStart()
    {
        StartCoroutine(After());
    }

    IEnumerator After()
    {
        _cat.fallingMug();
        yield return new WaitForSeconds(1f);
        _cat.Walk(DifferentsMoves[3].position);
    }

    void DogSpawn()
    {
        StartCoroutine(teleenable());
    }

    IEnumerator teleenable()
    {
        yield return new WaitForSeconds(1f);
        player.colliderTV.enabled = false;
        tele.SetActive(true);
        _cat.Scared();
        yield return new WaitForSeconds(3f);
        tele.SetActive(false);
    }

    void BreakDance()
    {
        _cat.BreakDance();
    }

    void Krokmou()
    {
        _cat.Krokmou();
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
        
        else if (nameIndex == "Herbe")
        {
            player.Herbe();
        }
    }
    public void EnableObject()
    {
        allObjectsPickUp[0].enableToTake = true;
    }

    public void EnableHerbe()
    {
        allObjectsPickUp[2].enableToTake = true;
    }
}
