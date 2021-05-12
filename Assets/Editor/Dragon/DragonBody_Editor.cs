using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dragon))]
public class DragonBody_Editor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Dragon script = target as Dragon;

        if (GUILayout.Button("InsertBodyPart"))
        {
            script.AddBone();
        }

        if (GUILayout.Button("DeleteBodyPart"))
        {
            script.DeleteBodyPart();
        }

        //if (GUILayout.Button("ScaleAlongBody"))
        //{
        //    script.StartDragonSwalowCoroutine();
        //}
    }

}
