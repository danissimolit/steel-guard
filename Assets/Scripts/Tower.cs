using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform _weapon;
    [SerializeField] Transform _enemy;
    [SerializeField] Transform _closestWaypoint;

    void Start()
    {
        _closestWaypoint = FindClosestPathWaypoint();

        if (_closestWaypoint != null)
        {
            LookAtTargetY(transform, _closestWaypoint.position);
        }

        _enemy = FindFirstObjectByType<EnemyMover>()?.transform;

        //Vector3 target = Vector3.zero;

        //if (_enemy != null)
        //{
        //    target = _enemy.transform.position;
        //}

        //LookAtTargetY(transform, target); // Make the tower look at enemy
    }

    void Update()
    {
        LookAtEnemy();
    }

    private void LookAtEnemy()
    {
        if (_enemy != null)
        {
            LookAtTargetY(_weapon, _enemy.position);
        }
    }

    private void LookAtTargetY(Transform gameObj, Vector3 target)
    {
        Vector3 direction = target - gameObj.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            gameObj.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        }
    }

    private Transform FindClosestPathWaypoint()
    {
        Waypoint[] allWaypoints = FindObjectsOfType<Waypoint>();

        Transform nearestWaypoint = null;
        float closestDistance = Mathf.Infinity;

        foreach (Waypoint waypoint in allWaypoints)
        {
            if (waypoint.transform.parent.name == "Path")
            {
                float distance = Vector3.Distance(transform.position, waypoint.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestWaypoint = waypoint.transform;
                }
            }
        }

        return nearestWaypoint;
    }
}
