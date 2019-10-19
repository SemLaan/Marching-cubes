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

    }

}
