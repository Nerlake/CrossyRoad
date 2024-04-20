using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private const string LOG_TAG = "Log";
    private const string VEHICLE_TAG = "Vehicle";
    private const string WATER_TAG = "Water";

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case LOG_TAG:
                transform.parent = collision.collider.transform;
                break;
            default:
                transform.parent = null;
                break;
        }
    }



    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player collided with " + other.tag);
        switch (other.tag)
        {
            case VEHICLE_TAG:
                Destroy(gameObject);
                break;
            case WATER_TAG:
                Debug.Log("Player fell in water");
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
