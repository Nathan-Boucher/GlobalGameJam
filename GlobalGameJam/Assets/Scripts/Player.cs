using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject mugPrefab , telecommandePrefab , chaussonPrefab , herbePrefab;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private bool mugUsed , chaussonUsed , herbeUsed;
    [SerializeField] public BoxCollider2D colliderTV,colliderCat;

    void Start()
    {
        colliderTV.enabled = false;
    }
    public void Laser()
    {
        Debug.Log(("J'utilise le laser"));
    }

    public void Telecommande()
    {
        Debug.Log(("J'utilise la télécommande"));
        GameObject obj = Instantiate(telecommandePrefab, spawnPosition.position, Quaternion.identity);
    }

    public void Mug()
    {
        if (!mugUsed)
        {
            Debug.Log("J'utilise le mug");
            GameObject obj =  Instantiate(mugPrefab, spawnPosition.position , Quaternion.identity);
        }
        mugUsed = true;
    }

    public void Chausson()
    {
        if (!chaussonUsed)
        {
            Debug.Log("J'utilise les chaussons");
            GameObject obj = Instantiate(chaussonPrefab, spawnPosition.position, Quaternion.identity);
        }
        chaussonUsed = true;
    }

    public void Herbe()
    {
        if (!herbeUsed)
        {
            Debug.Log("J'utilise l'herbe");
            GameObject obj = Instantiate(herbePrefab, spawnPosition.position, Quaternion.identity);
        }
        herbeUsed = true;
    }
}
