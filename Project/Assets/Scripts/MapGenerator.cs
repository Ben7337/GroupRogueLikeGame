using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour
{
    public Grid grid;
    public Tilemap wallTilemap;
    public Tilemap floorTilemap;
    public int height;
    public int width;
    public Tile wall;
    public Tile dirt;
    public float perlinWidth;
    public float frequency;
    public CellularAutomata cellular;

    public GameObject treasure;
    public GameObject player;
    public GameObject camera;
    public GameObject enemy;

    public int enemyNumber;

    private Texture2D noiseTex;
    private bool[,] wallMap;
    private float seed;


    // Start is called before the first frame update
    void Start()
    {
        seed = Random.Range(-1000f, 1000f);

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (Mathf.PerlinNoise((i / perlinWidth) + seed, (j / perlinWidth) + seed) > frequency)
                {
                    floorTilemap.SetTile(new Vector3Int(i, j, 0), dirt);
                }
            }
        }

        cellular.height = height;
        cellular.width = width;
        wallMap = new bool[width, height];
        wallMap = cellular.generateMap();

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (wallMap[i, j])
                {
                    wallTilemap.SetTile(new Vector3Int(i, j, 0), wall);
                }
            }
        }

        placeObjects(treasure, 5);
        player = Instantiate(player, grid.CellToWorld(findCenteredEmptyTile()) + new Vector3(.2f, .2f, 0), Quaternion.identity);
        camera = Instantiate(camera);
        camera.GetComponent<CameraFollow>().setFollowObject(player);

        enemy.GetComponent<FirstEnemy>().attackRadius = .13f;

        for (int i = 0; i < enemyNumber; i++)
            Instantiate(enemy, grid.CellToWorld(getRandomEmptyTile(30)), Quaternion.identity);
    }


    public void destroyTileFromWorldSpace(Vector3 worldVector)
    {
        //Debug.Log(worldVector);
        wallTilemap.SetTile(grid.WorldToCell(worldVector), null);
    }

    public void placeObjects(GameObject spawnObject, int rarityWallCount)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (!wallMap[x, y])
                {
                    int nbs = cellular.countAliveNeighbours(wallMap, x, y);
                    if (nbs >= rarityWallCount)
                    {
                        Instantiate(spawnObject, grid.CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity);
                    }
                }
            }
        }
    }

    public Vector3Int findCenteredEmptyTile()
    {
        int quarterHeight = height / 4;
        int halfHeight = height / 2;
        for (int i = halfHeight - quarterHeight; i <= halfHeight + quarterHeight; i++)
        {
            for (int j = halfHeight - quarterHeight; j <= halfHeight + quarterHeight; j++)
            {
                if (!wallMap[i, j])
                    return new Vector3Int(i, j, 0);
            }
        }
        return new Vector3Int(halfHeight, halfHeight, 0);
    }

    public Vector3Int getRandomTile()
    {
        return new Vector3Int(Random.Range(0, width), Random.Range(0, height), 0);
    }

    public Vector3Int getRandomEmptyTile(int maxRepititions)
    {
        Vector3Int randomTile;
        for(int i = 0; i < maxRepititions; i++)
        {
            randomTile = getRandomTile();
            if(!wallMap[randomTile.x, randomTile.y])
            {
                return new Vector3Int(randomTile.x, randomTile.y, 0);
            }
        }
        int halfHeight = height / 2;
        return new Vector3Int(halfHeight, halfHeight, 0);
    }
}
