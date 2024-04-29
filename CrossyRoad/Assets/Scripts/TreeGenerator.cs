using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private int minPosition;
    [SerializeField] private int maxPosition;
    [SerializeField] private int treeCount;


    void Start()
    {
        for (int i = 0; i < treeCount; i++)
        {
            float randomX = Random.Range(minPosition, maxPosition);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);
            GameObject newTree = Instantiate(treePrefab, spawnPosition, Quaternion.identity);
            newTree.transform.SetParent(transform);
        }
    }

}
