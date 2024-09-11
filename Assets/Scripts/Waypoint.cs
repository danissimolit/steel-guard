using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool _isPlaceable;

    public bool IsPlaceable()
    {
        return _isPlaceable;
    }
}
