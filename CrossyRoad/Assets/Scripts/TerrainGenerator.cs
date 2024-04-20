using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private List<GameObject> terrainPrefabsGroup;
    [SerializeField] private int maxTerrainGroupCount;
    [SerializeField] private int minDistanceFromLastTerrain;
    private List<GameObject> listTerrainPrefabs;
    private float zPosition = 0;

    void Start()
    {
        listTerrainPrefabs = new List<GameObject>();
        zPosition = transform.position.z;
        GenerateTerrain();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GenerateTerrain()
    {
        for (int i = 0; i < maxTerrainGroupCount; i++)
        {
            int randomTerrainIndex = Random.Range(0, terrainPrefabsGroup.Count);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
            GameObject generateTerrainGroup = Instantiate(terrainPrefabsGroup[randomTerrainIndex], spawnPosition, Quaternion.identity);
            generateTerrainGroup.transform.SetParent(transform);
            listTerrainPrefabs.Add(generateTerrainGroup);
            zPosition += generateTerrainGroup.GetComponent<TerrainGroupGenerator>().GetTerrainCount();
        }
    }

    public void GenerateNewTerrain(Vector3 playerPosition)
    {
        Debug.Log("GenerateNewTerrain");
        int lastTerrainPosition = GetLastTerrainPositionZ();
        if (playerPosition.z - lastTerrainPosition < minDistanceFromLastTerrain) return;
        GenerateTerrain();
        DestroyTerrain();
    }

    private void DestroyTerrain()
    {
        GameObject firstTerrain = listTerrainPrefabs.FirstOrDefault();
        Destroy(firstTerrain);
        listTerrainPrefabs.Remove(firstTerrain);
    }

    private int GetLastTerrainPositionZ()
    {
        GameObject lastGroup = listTerrainPrefabs.LastOrDefault();
        if (lastGroup != null)
        {
        return lastGroup.GetComponent<TerrainGroupGenerator>().GetLastTerrainPosition();

        }
        return 0;
    }
}
