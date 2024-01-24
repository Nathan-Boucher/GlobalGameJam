using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject mugPrefab;
    [SerializeField] private Transform spawnPosition;
    public void Laser()
    {
        Debug.Log(("J'utilise le laser"));
    }

    public void Telecommande()
    {
        Debug.Log(("J'utilise la télécommande"));
    }

    public void Mug()
    {
        Debug.Log("J'utilise le mug");
        GameObject obj =  Instantiate(mugPrefab, spawnPosition.position , Quaternion.identity);
    }
}
