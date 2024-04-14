using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class OnePlace : MonoBehaviour
{
    [SerializeField] public Transform positionPlace;
    [SerializeField] public string name, nextMove;
    [SerializeField] public Vector3 nextPosition;
    

    void Start()
    {
        positionPlace = transform;
        name = gameObject.name;
    }
}
