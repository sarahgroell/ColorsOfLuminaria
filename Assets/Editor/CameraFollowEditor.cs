﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraFollow))]
public class CameraFollowEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CameraFollow cf = (CameraFollow)target;

        if(GUILayout.Button("Set Min Cam Pos"))
        {
            cf.setMinCamPosition();
        }
        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cf.setMaxCamPosition();
        }
    }
}
