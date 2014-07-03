using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateRainbow))]

public class GenerateRainbowEditor : Editor
{
	public override void OnInspectorGUI()
    {
        GenerateRainbow generateRainbowBeingInspected = target as GenerateRainbow;
        base.OnInspectorGUI();
        if (GUILayout.Button("New Rainbow"))
        {
           generateRainbowBeingInspected.New();
        }
	}

}

