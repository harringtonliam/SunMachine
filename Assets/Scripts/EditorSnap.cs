using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Gridpoint))]
public class EditorSnap : MonoBehaviour
{
    Gridpoint gridpoint;


    private void Awake()
    {
        gridpoint = GetComponent<Gridpoint>();
    }


    // Update is called once per frame
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = gridpoint.GridSize;
        Vector3 vector3 = new Vector3(
            gridpoint.GridPosition.x * gridSize,
            0f,
            gridpoint.GridPosition.y * gridSize);
        transform.position = vector3;
    }

    private void UpdateLabel()
    {
        TextMesh label = GetComponentInChildren<TextMesh>();
        if (label != null)
        {
            int gridSize = gridpoint.GridSize;
            string labelText = (gridpoint.GridPosition.x) + "," + (gridpoint.GridPosition.y);
            label.text = labelText;
            gameObject.name = "Cube" + labelText;
        }
        
    }
}
