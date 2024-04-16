using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float _cameraSpeed = 3.0f;

    [SerializeField] public bool readyForForwardAnimation = false;

    private void Update()
    {
        if (readyForForwardAnimation)
        {
            StartCoroutine(ForwardAnimation());
            readyForForwardAnimation = false;
        }
    }

    private IEnumerator ForwardAnimation()
    {
        float duration = 2.0f;
        float startTime = Time.time;
        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + Vector3.right * _cameraSpeed;

        while (Time.time < startTime + duration)
        {
            // Interpolation linéaire de la position de départ à la position finale sur la durée spécifiée
            transform.position = Vector3.Lerp(startPosition, endPosition, (Time.time - startTime) / duration);
            yield return null;
        }

        // Assurez-vous que la position finale est bien atteinte en fin d'animation
        transform.position = endPosition;

        // L'animation est terminée, vous pouvez ici remettre readyForForwardAnimation à false ou effectuer d'autres actions
    }
}