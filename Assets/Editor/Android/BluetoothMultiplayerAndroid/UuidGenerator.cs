using System;
using UnityEditor;
using UnityEngine;


public class UuidGenerator : EditorWindow {

    [MenuItem("Component/Lost Polygon/Android Bluetooth Multiplayer/UUID generator")]
    static void ShowWindow() {
        #if UNITY_ANDROID
            EditorWindow.GetWindow<UuidGenerator>();
        #else
            EditorUtility.DisplayDialog("Wrong build platform", "Build platform was not set to Android. Please choose Android as build Platform in File - Build Settings...", "OK");
        #endif
    }

    #if UNITY_ANDROID
    private string _uuid = "";

    void OnGUI() {
        EditorGUILayout.LabelField("Random generated UUID: ");
        _uuid = EditorGUILayout.TextField(_uuid);

        if (GUILayout.Button("Generate new UUID") || _uuid == "") {
            _uuid = Guid.NewGuid().ToString();
        }
    }
    #endif
}

