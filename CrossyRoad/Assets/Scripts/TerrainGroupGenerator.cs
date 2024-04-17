using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGroupGenerator : MonoBehaviour
{

    [SerializeField] private GameObject terrainPrefab;
    [SerializeField] private int minTerrainCount;
    [SerializeField] private int maxTerrainCount;
    public List<GameObject> listTerrainPrefabs;

    void Awake()
    {
        listTerrainPrefabs = new List<GameObject>();
        int terrainCount = Random.Range(minTerrainCount, maxTerrainCount + 1); 
        for (int i = 0; i < terrainCount; i++) 
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + i); 
            GameObject instantiatedTerrain = Instantiate(terrainPrefab, spawnPosition, Quaternion.identity, transform);
            listTerrainPrefabs.Add(instantiatedTerrain); 
        }
    }

    public int GetTerrainCount()
    {
        if(listTerrainPrefabs == null)
        {
            return 0;
        }
        else
        {
            return listTerrainPrefabs.Count;
        }
    }
}
