
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class GridMenu : EditorWindow
{
    [MenuItem("Grid/Snap any snaps")]
    static void SnapAll()
    {
        SnapToGrid[] snaps = FindObjectsOfType<SnapToGrid>();
        for (int i=0; i<snaps.Length; i++)
        {
            snaps [i].Snap();
        }
    }
    void OnGUI()
    {
        if (GUILayout.Button("Snap any objects with snaps"))
        {
            SnapAll();
        }
    }
    
    [MenuItem("Grid/Grid Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<GridMenu>();
    }
}

#endif