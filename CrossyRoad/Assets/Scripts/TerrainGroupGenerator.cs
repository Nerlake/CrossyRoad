using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGroupGenerator : MonoBehaviour
{

    [SerializeField] private GameObject terrainPrefab;
    [SerializeField] private int minTerrainCount;
    [SerializeField] private int maxTerrainCount;
    public List<GameObject> listTerrainPrefabs;

    void Start()
    {
        int terrainCount = Random.Range(minTerrainCount, maxTerrainCount);
        for(int i=0; i<= terrainCount; i++)
        {
            Vector3 spawnPosition = new Vector3(i, transform.position.y, transform.position.z);
            Instantiate(terrainPrefab, spawnPosition, Quaternion.identity);
            listTerrainPrefabs.Add(terrainPrefab);
        }
    }
}
