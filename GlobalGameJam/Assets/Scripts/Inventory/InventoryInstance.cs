using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryInstance : MonoBehaviour
{
    public Objects objet;
    
    public InventoryInstance(Objects objet)
    {
        this.objet = objet;
    }
}
