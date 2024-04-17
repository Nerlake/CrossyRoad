using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float translationX = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float translationZ = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        transform.Translate(translationX, 0, translationZ);

    }
}
