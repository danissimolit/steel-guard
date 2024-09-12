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

    public void PlaceTower(Transform tower)
    {
        if (!_isPlaceable) return;

        Instantiate(tower, transform.position, Quaternion.identity);
        _isPlaceable = false;
    }
}
