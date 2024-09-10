using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coords;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        coords = new Vector2Int();
        DisplayCoords();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoords();
            UpdateObjectName();
        }
    }

    private void DisplayCoords()
    {
        coords.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coords.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = $"{coords.x},{coords.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coords.ToString();
    }
}
