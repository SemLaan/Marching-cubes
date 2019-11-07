using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainManager))]
public class MapEditor : Editor
{

    //private LayerMask environment;


    private void OnEnable()
    {

        //environment = LayerMask.GetMask("None");

    }


    private void OnSceneGUI()
    {

        Event guiEvent = Event.current;

        Ray ray = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
        RaycastHit rayHit = new RaycastHit();

        Physics.Raycast(ray, out rayHit, 1000);

    }



    public override void OnInspectorGUI()
    {

        TerrainManager mapGen = target as TerrainManager;

        DrawDefaultInspector();

        if (GUILayout.Button("Regenerate"))
        {

            mapGen.RegenerateTerrain();

        }

    }

}
