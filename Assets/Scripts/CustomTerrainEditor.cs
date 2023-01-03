using UnityEngine;
using UnityEditor;
using EditorGUITable;


[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]



public class CustomTerrainEditor : Editor
{

    //show menus bools
    bool showPerlinNoise = false;
    bool showMultiplePerlin = false;

    //properties
    SerializedProperty resetTerrain;
    SerializedProperty heightMapScale;
    SerializedProperty heightMapImage;
    SerializedProperty xScale;
    SerializedProperty yScale;
    SerializedProperty xOffset;
    SerializedProperty yOffset;
    SerializedProperty octaves;
    SerializedProperty persistance;
    SerializedProperty heightScale;
    
   


    

    void OnEnable() 
    {
        resetTerrain = serializedObject.FindProperty("resetTerrain");
        xScale = serializedObject.FindProperty("xScale");
        yScale = serializedObject.FindProperty("yScale");
        xOffset = serializedObject.FindProperty("xOffset");
        yOffset = serializedObject.FindProperty("yOffset");
        octaves = serializedObject.FindProperty("octaves");
        persistance = serializedObject.FindProperty("persistance");
        heightScale = serializedObject.FindProperty("heightScale");
        
    }

    public override void OnInspectorGUI()
    {
         serializedObject.Update();

        CustomTerrain terrain = (CustomTerrain) target;
        EditorGUILayout.PropertyField(resetTerrain);


        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Reset Terrain"))
        {
            terrain.ResetTerrain();
        }

       showPerlinNoise = EditorGUILayout.Foldout(showPerlinNoise, "Single Perlin Noise");
       if (showPerlinNoise)
       {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            GUILayout.Label("Perlin Noise", EditorStyles.boldLabel);
            EditorGUILayout.Slider(xScale, 0, 1, new GUIContent("X Scale"));
            EditorGUILayout.Slider(yScale, 0, 1, new GUIContent("Y Scale"));
            EditorGUILayout.IntSlider(xOffset, 0, 10000, new GUIContent("Offset X"));
            EditorGUILayout.IntSlider(yOffset, 0, 10000, new GUIContent("Offset Y"));
            EditorGUILayout.IntSlider(octaves, 1, 10, new GUIContent("Octaves"));
            EditorGUILayout.Slider(persistance, 0.1f, 10, new GUIContent("Persistance"));
            EditorGUILayout.Slider(heightScale, 0, 1, new GUIContent("hightScale"));
            if (GUILayout.Button("Genrate Terrain"))
            {
                terrain.PerlinNoise();
            }
            
       }

      


         serializedObject.ApplyModifiedProperties();

    }



}
