using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassController : MonoBehaviour
{
    [SerializeField] private GameObject tree;

    private void Start()
    {
        int lenghtOfZone = 10;

        for (int i = -lenghtOfZone; i <= lenghtOfZone; i++)
        {
            if (i < -6 || i > 6)
            {
                for (int j = 1; j < Random.Range(1, 5); j++)
                {
                    GameObject newTree = Instantiate(
                        tree,
                        transform.position + Vector3.right * i + Vector3.up * j,
                        transform.rotation
                    );

                    newTree.transform.SetParent(gameObject.transform);
                }
            }
            else
            {
                if (Random.Range(0, 10) == 2)
                {
                    GameObject newTree = Instantiate(
                        tree,
                        transform.position + Vector3.right * i + Vector3.up,
                        transform.rotation
                    );
                }
            }
        }
    }
}