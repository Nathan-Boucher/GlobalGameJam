using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Objects/New Object" , order = 1)]
public class Objects : ScriptableObject
{
    public string name;
    public Sprite sprite;
}
