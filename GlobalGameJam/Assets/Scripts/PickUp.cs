using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : MonoBehaviour
{
    public static event Action<InventoryInstance> pickupItem;
    public static event Action pickUpMug;
    public InventoryInstance item;
    public bool enableToTake;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip mug, grab;
    private void OnMouseDown()
    {
        if (enableToTake)
        {
            pickupItem.Invoke(item);
            if (item.objet.name == "Mug")
            {
                _audioSource.clip = mug;
                _audioSource.Play();
                pickUpMug.Invoke();
            }
            else
            {
                _audioSource.clip = grab;
                _audioSource.loop = false;
                _audioSource.Play();
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator PlayAudio(float time)
    {
        yield return new WaitForSeconds(time);
        _audioSource.Play();
    }
}
