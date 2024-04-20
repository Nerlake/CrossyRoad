using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator _animator;
    private bool isJumping = false;
    private const string LOG_TAG = "Log";
    private const string VEHICLE_TAG = "Vehicle";
    private const string WATER_TAG = "Water";

    private void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBackward();
        }

    }

    private void MoveForward()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Jump();
    }

    private void MoveBackward()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        Jump();
    }

    private void MoveLeft()
    {
        transform.rotation = Quaternion.Euler(0, -90, 0);
        Jump();
    }

    private void MoveRight()
    {
        transform.rotation = Quaternion.Euler(0, 90, 0);
        Jump();
    }

    public void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            _animator.SetTrigger("Jump");
            Vector3 newPosition = transform.position + transform.forward * 1;
            newPosition.x = Mathf.Round(newPosition.x);
            newPosition.z = Mathf.Round(newPosition.z);
            transform.position = newPosition;
        }
    }

    public void EndJump()
    {
        isJumping = false;
    }

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