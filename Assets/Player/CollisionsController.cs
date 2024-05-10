using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        print("CollisionsController: Collision avec " + other.gameObject.name);
    }
}
