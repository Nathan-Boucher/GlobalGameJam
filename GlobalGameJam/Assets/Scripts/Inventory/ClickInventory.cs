using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickInventory : MonoBehaviour
{
    [SerializeField] private GameObject menuDeroulant,hand;
    [SerializeField] private bool stateInventory;
    public static event Action<int> selectItem; 
    public void OnClickSlot(int index)
    {
        selectItem?.Invoke(index);
    }

    public void HandInventory()
    {
        stateInventory = !stateInventory;
        if (stateInventory)
        {
            menuDeroulant.SetActive(true);
            hand.SetActive(false);
        }
        else
        {
            menuDeroulant.SetActive(false);
            hand.SetActive(true);
        }
    }
}
