using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(WorldGen))]
public class LabirynthEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        WorldGen generator = (WorldGen)target;
        if (GUILayout.Button("Generate Labirynt"))
        {
            generator.GenerateLabirynth();
        }
    }

   
}
