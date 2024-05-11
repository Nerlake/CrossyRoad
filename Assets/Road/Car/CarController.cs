using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovable
{
    public void SetSpeed(float newSpeed);
}

public class CarController : MonoBehaviour, IMovable
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<DeadControllerOfPlayer>().OnDeadBecauseVehicleCollision();
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}