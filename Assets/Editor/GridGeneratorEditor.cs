using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridGenerator))]
public class GridGeneratorEditor : Editor
{
    GridGenerator grid;

    private void Awake()
    {
        grid = (GridGenerator) target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Generate Grid"))
        {
            grid.ClearGrid();
            grid.GenerateGrid();
        }
    }
}
