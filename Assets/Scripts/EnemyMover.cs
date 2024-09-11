using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> _waypoints;
    [SerializeField, Range(-5f, 5f)] private float _movingSpeed;

    private void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (var waypoint in _waypoints)
        {
            Vector3 currentTilePos = transform.position;
            Vector3 targetTilePos = waypoint.transform.position;
            float travelPercent = 0f;
            transform.LookAt(targetTilePos);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * _movingSpeed;
                transform.position = Vector3.Lerp(currentTilePos, targetTilePos, travelPercent);

                yield return new WaitForEndOfFrame();
            }
        }
    }
}
