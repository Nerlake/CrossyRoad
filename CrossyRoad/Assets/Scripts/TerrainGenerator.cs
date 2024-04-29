using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private int minDistanceBetweenLastTerrainAndPlayer;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Transform terrainHolder;

    private List<GameObject> currentTerrains = new List<GameObject>();
    public Vector3 currentPosition = new Vector3(0, 0, 0);

    private void Start()
    {

            InitialSpawnTerrain();

        maxTerrainCount = currentTerrains.Count;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        Debug.Log(DistanceBetweenLastTerrainAndPlayer(new Vector3(0,0,0)));
    //        GenerateTerrain();
    //    }
    //}

    private void InitialSpawnTerrain()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
                for (int j = 0; j < terrainInSuccession; j++)
                {
                    GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                    currentTerrains.Add(terrain);
                    currentPosition.z++;
                }
        }
    }

    public void GenerateTerrain(Vector3 playerPos)
    {
        if (DistanceBetweenLastTerrainAndPlayer(playerPos) < minDistanceBetweenLastTerrainAndPlayer)
        {
 
            int whichTerrain = Random.Range(0, terrainDatas.Count);
            int terrainInSuccession = Random.Range(1, terrainDatas[whichTerrain].maxInSuccession);
            for (int i = 0; i < terrainInSuccession; i++)
            {
                GameObject terrain = Instantiate(terrainDatas[whichTerrain].terrain, currentPosition, Quaternion.identity, terrainHolder);
                currentTerrains.Add(terrain);
                DestroyFirstTerrain();
                currentPosition.z++;
            }
        }
    }

    private void DestroyFirstTerrain()
    {
        if (currentTerrains.Count > maxTerrainCount)
        {
            Destroy(currentTerrains[0]);
            currentTerrains.RemoveAt(0);
        }
    }

    private float DistanceBetweenLastTerrainAndPlayer(Vector3 playerPos)
    {
        float distance = currentPosition.z - playerPos.z;
        return distance;
    }


}
