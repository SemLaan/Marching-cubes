using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGenerator
{

    public int[,,] DensityMatrix { get; private set; }
    private int gridSize;
    private float pointScale;
    private Transform pointContainer;
    private int _min;
    private float colorMultiplier;

    public int PointDensity(int x, int y, int z)
    {

        return DensityMatrix[x, y, z];

    }

    public PointGenerator(Transform _pointContainer, int min, int max, int _gridSize = 3, float _pointScale = 0.3f)
    {

        _min = min;
        colorMultiplier = max - min;

        pointContainer = _pointContainer;
        pointScale = _pointScale;
        gridSize = _gridSize;

        DensityMatrix = new int[gridSize, gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {

                    int rand = Random.Range(min, max + 1);

                    DensityMatrix[x, y, z] = rand;
                }
            }
        }

        System.Console.WriteLine(DensityMatrix);

    }

    public void DrawPoints()
    {
        
        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                for (int z = 0; z < gridSize; z++)
                {

                    GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    sphere.transform.position = new Vector3(x, y, z);
                    sphere.transform.localScale = new Vector3(pointScale, pointScale, pointScale);
                    sphere.transform.SetParent(pointContainer);
                    if (PointDensity(x, y, z) <= 0)
                    {

                        MeshRenderer meshRenderer = sphere.GetComponent<MeshRenderer>();

                        meshRenderer.material.color = Color.HSVToRGB(1, 0, (PointDensity(x, y, z) - _min) / colorMultiplier);
                    }

                }
            }
        }

    }

}
