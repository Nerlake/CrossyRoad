using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float distance = 1.0f;
    [SerializeField] private Animator animator;

    void Start()
    {
        //StartCoroutine(MovePlayer());
    }

    // Update is called once per frame
    void Update()
    {
   
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("TrJump");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetTrigger("TrJump");
        }
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetTrigger("TrJump");

        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
            animator.SetTrigger("TrJump");
            transform.position += transform.forward * distance;
        }
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("TrJump");
            transform.position -= transform.forward * distance;
        }

    }

    void OnBecameVisible()
    {
        Debug.Log(gameObject.name + " est maintenant visible par au moins une caméra.");
    }

    void OnBecameInvisible()
    {
        Debug.Log(gameObject.name + " n'est plus visible par aucune caméra.");
    }

    //private IEnumerator MovePlayer()
    //{
    //    while (true)  // Assure que la coroutine continue à s'exécuter
    //    {
    //        float translationX = Input.GetAxisRaw("Vertical");
    //        float translationZ = Input.GetAxis("Horizontal");

    //        if (translationZ > 0)
    //        {
    //            animator.SetTrigger("trJump");

    //        }
    //        if (translationZ < 0)
    //        {
    //            transform.position -= transform.forward * distance;
    //        }
    //        if (translationX > 0)
    //        {
    //            transform.position += transform.right * distance;
    //        }
    //        if (translationX < 0)
    //        {
    //            transform.position -= transform.right * distance;
    //        }

    //        yield return new WaitForSeconds(0.4f); // Attendre une seconde
    //    }
    //}
}
