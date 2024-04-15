using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{

    [SerializeField] private List<GameObject> terrainPrefabsGroup;
    [SerializeField] private int maxTerrainGroupCount;
    private List<GameObject> listTerrainPrefabs;
    private float xPosition = 0;

    void Start()
    {
        listTerrainPrefabs = new List<GameObject>();
        xPosition = transform.position.x;
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
            Vector3 spawnPosition = new Vector3(xPosition, transform.position.y, transform.position.z);
            GameObject generateTerrainGroup = Instantiate(terrainPrefabsGroup[randomTerrainIndex], spawnPosition, Quaternion.identity);
            listTerrainPrefabs.Add(generateTerrainGroup);
            xPosition += generateTerrainGroup.GetComponent<TerrainGroupGenerator>().GetTerrainCount();
        }
    }
}
