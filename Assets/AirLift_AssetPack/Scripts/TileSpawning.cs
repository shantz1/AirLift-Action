using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawning : MonoBehaviour
{
    public GameObject[] terrainPrefabs;
    public float spawnZ = 0f;
    public float tileLength = 10f;
    public float PlayerPositionMultipler = 70f;
    public int maxTilesOnScreen = 5;
    public GameObject player;

    private float spawnZPosition;
    private float endZPosition;
    private int terrainIndex = 0;
    private Queue<GameObject> terrainQueue = new Queue<GameObject>();

    void Start()
    {
        spawnZPosition = spawnZ;
        endZPosition = spawnZ + tileLength;
        SpawnTerrain();
    }

    void Update()
    {
        if (player.transform.position.z + PlayerPositionMultipler >= endZPosition )
        {
            SpawnTerrain();
        }
    }

    void SpawnTerrain()
    {
        GameObject terrain = Instantiate(terrainPrefabs[terrainIndex]);
        terrain.transform.position = new Vector3(0, 0, endZPosition);
        endZPosition += tileLength;
        terrainQueue.Enqueue(terrain);

        if (terrainQueue.Count > maxTilesOnScreen)
        {
            GameObject oldestTerrain = terrainQueue.Dequeue();
            Destroy(oldestTerrain);
        }

        terrainIndex++;

        if (terrainIndex >= terrainPrefabs.Length)
        {
            terrainIndex = 0;
        }
    }
}