using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TerrainManager))]
public class MapEditor : Editor
{

    //private LayerMask environment;
    private TerrainManager mapGen;

    private void OnEnable()
    {

        //environment = LayerMask.GetMask("None");

    }


    private void OnSceneGUI()
    {

        Event guiEvent = Event.current;

        if (guiEvent.type == EventType.MouseDown && guiEvent.button == 0)
        {

            Ray ray = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition);
            RaycastHit rayHit = new RaycastHit();

            Debug.Log(Physics.Raycast(ray, out rayHit, 1000f));

            if (Physics.Raycast(ray, out rayHit, 1000f))
            {

                Vector3 voxelCoord = rayHit.point;

                voxelCoord.x = Mathf.Round(voxelCoord.x);
                voxelCoord.y = Mathf.Round(voxelCoord.y) + 2;
                voxelCoord.z = Mathf.Round(voxelCoord.z);

                mapGen.densityTensor[(int)voxelCoord.x, (int)voxelCoord.y, (int)voxelCoord.z] = -10;
                mapGen.densityTensor[(int)voxelCoord.x+1, (int)voxelCoord.y, (int)voxelCoord.z] = -10;
                mapGen.densityTensor[(int)voxelCoord.x-1, (int)voxelCoord.y, (int)voxelCoord.z] = -10;
                mapGen.densityTensor[(int)voxelCoord.x, (int)voxelCoord.y+1, (int)voxelCoord.z] = -10;
                mapGen.densityTensor[(int)voxelCoord.x, (int)voxelCoord.y-1, (int)voxelCoord.z] = -10;
                mapGen.densityTensor[(int)voxelCoord.x, (int)voxelCoord.y, (int)voxelCoord.z+1] = -10;
                mapGen.densityTensor[(int)voxelCoord.x, (int)voxelCoord.y, (int)voxelCoord.z-1] = -10;
                mapGen.RedrawTerrain();
            }
        }
    }



    public override void OnInspectorGUI()
    {

        mapGen = target as TerrainManager;

        DrawDefaultInspector();

        if (GUILayout.Button("Regenerate"))
        {

            mapGen.RegenerateTerrain();

        }

    }

}
