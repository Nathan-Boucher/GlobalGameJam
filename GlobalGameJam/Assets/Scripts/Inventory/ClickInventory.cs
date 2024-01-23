using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickInventory : MonoBehaviour
{
    public static event Action<int> selectItem; 
    public void OnClickSlot(int index)
    {
        selectItem?.Invoke(index);
    }
}
