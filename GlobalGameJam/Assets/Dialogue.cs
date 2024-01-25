using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private string[] dialogues;
    [SerializeField] private int index;

    [SerializeField] private Text montexte;
    [SerializeField] private GameObject mabulle;

    private void Start()
    {
        Bulle();
        PickUp.pickUpMug += Bulle;
        Cat.catsleep += Bulle;
        Cat.teleEnd += Bulle;
    }

    void Bulle()
    {
        montexte.gameObject.SetActive(true);
        mabulle.SetActive(true);
        montexte.text = dialogues[index];
        index++;
        StartCoroutine(timeBulle());
    }

    IEnumerator timeBulle()
    {
        yield return new WaitForSeconds(5f);
        montexte.gameObject.SetActive(false);
        mabulle.SetActive(false);
    }
}
