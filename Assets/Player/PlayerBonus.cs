using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonus : MonoBehaviour
{

    private LifesContoller lifeController;
    [SerializeField] private AudioSource gettingHearthSound;
    // Start is called before the first frame update
    void Start()
    {
        lifeController = GameObject.Find("lifes").GetComponent<LifesContoller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hearth"))
        {
            if (lifeController.AddOneLife())
            {
                gettingHearthSound.Play();
                Destroy(other.gameObject);
            }
        }
    }
}
