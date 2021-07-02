using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof (FlyingNodeManager))]
public class FlyingNodeManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        FlyingNodeManager nodeManager = (FlyingNodeManager)target;

        DrawDefaultInspector();

        if (GUILayout.Button("BAKE NODES"))
        {
            nodeManager.BakeNodes();
        }

        if (GUILayout.Button("TOGGLE GIZMOS"))
        {
            nodeManager.ToggleGizmos();
        }

        if (GUILayout.Button("TOGGLE SEARCH RADIUS WIREFRAME"))
        {
            nodeManager.ToggleWireGizmos();
        }
    }
}
