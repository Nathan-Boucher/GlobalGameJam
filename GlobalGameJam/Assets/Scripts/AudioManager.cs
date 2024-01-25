using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _audiosource;
    public AudioClip droptelecommande,dogo;

    void Start()
    {
        Object.telecommandeDrop += allumerTele;
    }

    void allumerTele()
    {
        _audiosource.clip = droptelecommande;
        _audiosource.Play();
        StartCoroutine(Dog());
    }

    IEnumerator Dog()
    {
        yield return new WaitForSeconds(1f);
        _audiosource.clip = dogo;
        _audiosource.loop = true;
        _audiosource.Play();
        yield return new WaitForSeconds(3f);
        _audiosource.Stop();
    }
}
