using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingCubes : MonoBehaviour
{

    PointGenerator pointGenerator;

    [SerializeField] private Transform pointHolder;
    [SerializeField] private float pointScale;
    [SerializeField] private int gridSize;

    private void Awake()
    {
        

        pointGenerator = new PointGenerator(pointHolder, -10, 10, gridSize, pointScale);

        pointGenerator.DrawPoints();

        CreateMesh();

    }

    private void CreateMesh()
    {

        for (int x = 0; x < gridSize-1; x++)
        {
            for (int y = 0; y < gridSize - 1; y++)
            {
                for (int z = 0; z < gridSize - 1; z++)
                {

                    int[] cubeValues = GetCube(x, y, z);
                    int cubeIndex = 0;

                    for (int i = 0; i < 8; i++)
                    {
                        if (cubeValues[i] < 0)
                            cubeIndex += 1 << i;
                    }



                }
            }
        }

    }

    private int[] GetCube(int x, int y, int z)
    {

        int[] cube = new int[8];

        cube[0] = pointGenerator.PointDensity(x, y, z);
        cube[1] = pointGenerator.PointDensity(x+1, y, z);
        cube[2] = pointGenerator.PointDensity(x+1, y, z+1);
        cube[3] = pointGenerator.PointDensity(x, y, z+1);
        cube[4] = pointGenerator.PointDensity(x, y+1, z);
        cube[5] = pointGenerator.PointDensity(x+1, y+1, z);
        cube[6] = pointGenerator.PointDensity(x+1, y+1, z+1);
        cube[7] = pointGenerator.PointDensity(x, y+1, z+1);

        return cube;

    }

}
