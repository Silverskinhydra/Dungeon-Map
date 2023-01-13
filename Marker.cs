using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField] private Object _object;

    void Start()
    {
        loc();
    }

    void loc()
    {
        float loc = transform.position.x;
        
        _object.name = loc.ToString();
    }
}
