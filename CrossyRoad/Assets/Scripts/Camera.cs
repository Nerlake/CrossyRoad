using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private float cameraSpeed = 0.5f;  // Vitesse à laquelle la caméra suit le joueur ou avance automatiquement
    [SerializeField] private GameObject player;         // Référence au GameObject du joueur
    [SerializeField] private float followThreshold = 5f; // Distance à partir de laquelle la caméra commence à suivre le joueur
    [SerializeField] private float autoMoveSpeed = 0.5f; // Vitesse de déplacement automatique de la caméra
    private float targetZPosition; // Position cible de la caméra en z
    [SerializeField] private bool autoMove = false;
    UnityEngine.Camera cam;

    private void Start()
    {
        cam = UnityEngine.Camera.main;
        targetZPosition = player.transform.position.z; // Initialisation de la position cible avec la position du joueur
    }

    private void Update()
    {
        if (player == null) return; 

        float playerPositionZ = player.transform.position.z;
        if (playerPositionZ > targetZPosition + followThreshold)
        {
            targetZPosition = playerPositionZ;
        }

        if (autoMove)
        {
            targetZPosition += autoMoveSpeed * Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Lerp(transform.position.z, targetZPosition, cameraSpeed * Time.deltaTime));

        IsThePlayerOutOfCamera();

    }

    public void IsThePlayerOutOfCamera()
    {
  
    }
}
