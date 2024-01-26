using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audiosource,_audioSource2;
    public AudioClip droptelecommande,dogo, krokmousong;

    void Start()
    {
        Object.telecommandeDrop += allumerTele;
        Object.herbeDrop += Krokmouuuu;
    }

    void allumerTele()
    {
        _audiosource.clip = droptelecommande;
        _audiosource.Play();
        StartCoroutine(Dog());
    }

public static event Action spawnDog;
    IEnumerator Dog()
    {
        yield return new WaitForSeconds(1f);
        spawnDog.Invoke();
        _audiosource.clip = dogo;
        _audiosource.loop = true;
        _audiosource.Play();
        yield return new WaitForSeconds(3f);
        _audiosource.Stop();
    }

    void Krokmouuuu()
    {
        _audioSource2.clip = krokmousong;
        _audioSource2.loop = true;
        _audioSource2.Play();
    }
}
