using System;
using UnityEditor;
using UnityEngine;

public class DeadControllerOfPlayer : MonoBehaviour
{
    private float totalTimeIdleSinceLastMoveOnZ;
    private float maxTimeBeforeDead = 2f;
    private float lastPositionOnZ;

    private void Start()
    {
        lastPositionOnZ = transform.position.z;
    }

    private void Update()
    {
        totalTimeIdleSinceLastMoveOnZ += Time.deltaTime;

        if (transform.position.z > lastPositionOnZ)
        {
            totalTimeIdleSinceLastMoveOnZ = 0;
            lastPositionOnZ = transform.position.z;
        }

        if (totalTimeIdleSinceLastMoveOnZ >= maxTimeBeforeDead)
        {
            OnDeadBecauseTooIdle();
        }
    }

    private void OnDeadBecauseTooIdle()
    {
        print("DeadControllerOfPlayer: Le joueur meurt car il est resté trop longtemps inactif");
        EditorApplication.isPlaying = false;
    }

    public void OnDeadBecauseOutsideOfFov()
    {
        print("DeadControllerOfPlayer: Le joueur meurt car il n'est plus dans la FOV");
        EditorApplication.isPlaying = false;
    }
}