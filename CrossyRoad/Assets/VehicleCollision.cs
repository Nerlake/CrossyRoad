using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    private const string PLAYER_TAG = "Player";

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case PLAYER_TAG:
                  //Destroy(collision.gameObject);
                  Debug.Log("(Vehicule)Player collided with vehicle");
                break;
            default:
                break;
        }
    }


    //void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag(PLAYER_TAG))
    //    {
    //        Destroy(other.gameObject);
    //    }
    //}

}
