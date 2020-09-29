using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this script was heavily inspired by michael cook's script for cellular automata
public class CellularAutomata : MonoBehaviour
{
    public int height = 100;
    public int width = 100;
    public int deathLimit;
    public int birthLimit;
    public float chanceToStartAlive = 0.45f;
    public int numberOfSteps;
    

    public bool[,] initialiseMap(bool[,] map)
    {
        width = map.GetLength(0);
        height = map.GetLength(1);
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.Range(0f, 1f) < chanceToStartAlive)
                {
                    map[x,y] = true;
                }
            }
        }
        return map;
    }

    public int countAliveNeighbours(bool[,] map, int x, int y)
    {
        int count = 0;
        for (int i = -1; i < 2; i++)
        {
            for (int j = -1; j < 2; j++)
            {
                int neighbour_x = x + i;
                int neighbour_y = y + j;
                if (i == 0 && j == 0)
                {
                }
                else if (neighbour_x < 0 || neighbour_y < 0 || neighbour_x >= map.GetLength(0) || neighbour_y >= map.GetLength(1))
                {
                    count = count + 1;
                }
                else if (map[neighbour_x,neighbour_y])
                {
                    count = count + 1;
                }
            }
        }
        return count;
    }

    public bool[,] doSimulationStep(bool[,] oldMap)
    {
        bool[,] newMap;
        newMap = new bool[width,height];
        for (int x = 0; x < oldMap.GetLength(0); x++)
        {
            for (int y = 0; y < oldMap.GetLength(1); y++)
            {
                int nbs = countAliveNeighbours(oldMap, x, y);
                if (oldMap[x,y])
                {
                    if (nbs < deathLimit)
                    {
                        newMap[x,y] = false;
                    }
                    else
                    {
                        newMap[x,y] = true;
                    }
                } 
                else
                {
                    if (nbs > birthLimit)
                    {
                        newMap[x,y] = true;
                    }
                    else
                    {
                        newMap[x,y] = false;
                    }
                }
            }
        }
        return newMap;
    }

    public bool[,] generateMap()
    {
        bool[,] cellmap = new bool[width,height];
        cellmap = initialiseMap(cellmap);
        for (int i = 0; i < numberOfSteps; i++)
        {
            cellmap = doSimulationStep(cellmap);
        }
        return cellmap;
    }
}
