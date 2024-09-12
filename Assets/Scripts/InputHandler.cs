using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _tower;

    private void Start()
    {
        _camera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;

        RaycastHit hitInfo;
        var hit = Physics.Raycast(_camera.ScreenPointToRay(Mouse.current.position.ReadValue()), out hitInfo);

        if (hit)
        {
            var waypoint = hitInfo.transform.GetComponent<Waypoint>();
            if (waypoint != null && waypoint.IsPlaceable())
            {
                Debug.Log(hitInfo.transform.name);
                waypoint.PlaceTower(_tower);
            }
        }
    }
}
