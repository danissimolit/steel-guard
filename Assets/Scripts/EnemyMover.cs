using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField] private float _movingDelay;

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in _waypoints)
        {
            Debug.Log(waypoint.transform.position);
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(_movingDelay);
        }
    }
}
