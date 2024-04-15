using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandGenerator : MonoBehaviour
{
    [SerializeField] private int _numberRoad;
    [SerializeField] private GameObject _road;

    private void Start()
    {
        for (int i = 0; i < _numberRoad; i++)
        {
            GameObject roadInstance = Instantiate(_road, new Vector3(i, 0, 0), Quaternion.identity);
            Road roadScript = roadInstance.GetComponent<Road>();

            if (i % 2 == 0)
                roadScript.reverse = true;
        }
    }
}