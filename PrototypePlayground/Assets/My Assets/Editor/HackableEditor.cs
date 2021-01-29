using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Hackable))]
public class HackableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // If we call base the default inspector will get drawn too.
        // Remove this line if you don't want that to happen.
        base.OnInspectorGUI();

        //var myScript = target as Hackable;

        //myScript.enableHackCost = EditorGUILayout.Toggle(myScript.enableHackCost,"Flag");

        //if (myScript.enableHackCost)
        //{
        //    myScript.hackGradient = EditorGUILayout.GradientField("Hack Rarity Color Gradient \t", myScript.hackGradient);
        //    myScript.hackCost = EditorGUILayout.IntSlider("Hack Cost \t",myScript.hackCost,1,myScript.MaxHackCost);
        //}

    }
}
