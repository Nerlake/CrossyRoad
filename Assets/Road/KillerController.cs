using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        // print("KillerController: Destruction de l'objet " + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
