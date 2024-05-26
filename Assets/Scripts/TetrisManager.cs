using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisManager : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    [SerializeField] private float koef = 0.5f;
    public bool[,] cells = new bool[22, 10];

    private void Start()
    {
        GenerateTable();
        Cube2x2();
    }

    private void GenerateTable()
    {
        float gridWidth = 22 * koef;
        float gridHeight = 10 * koef;
        float xOffset = gridWidth / 2 - koef / 2;
        float yOffset = gridHeight / 2 - koef / 2 + 0.5f;

        for (int i = 0; i < 22; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                float xpos = (i * koef) - xOffset;
                float ypos = (j * koef) - yOffset;
                Instantiate(cube, new Vector3(xpos, ypos, 0), Quaternion.identity);
                cells[i, j] = false;
            }
        }
    }

    private void Cube2x2()
    {
        cells[0, 9] = true;
    }
}
