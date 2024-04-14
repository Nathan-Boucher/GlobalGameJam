using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Barre : MonoBehaviour
{
    [SerializeField] private Image barreImage;
    [SerializeField] private float value;

    void Start()
    {
        Object.chaussonDrop += Up;
        AudioManager.spawnDog += Up;
        Cat.pushaction += Up;
        Object.herbeDrop += End;
    }

    void Up()
    {
        value += 1/3f;
        barreImage.fillAmount = value;
    }

    void End()
    {
        Destroy(gameObject);
    }
}
