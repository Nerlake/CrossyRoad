using UnityEditor;
using UnityEngine;

public class DeadControllerOfPlayer : MonoBehaviour
{
    private float totalTimeIdleSinceLastMoveOnZ;
    private float maxTimeBeforeDead = 10f;
    private float lastPositionOnZ;
    private float timeBeforeCheckAgainIsDeath = 1f;
    private float timeSinceLastDeath = 0f;

    private LifesContoller lifeController;

    private void Start()
    {
        lastPositionOnZ = transform.position.z;
        lifeController = GameObject.Find("lifes").GetComponent<LifesContoller>();
    }

    private void Update()
    {
        timeSinceLastDeath += Time.deltaTime;

        ManageIdleTime();
        ManageCollisionWithRiver();
    }

    private void ManageCollisionWithRiver()
    {
        Debug.DrawRay(transform.position, -transform.up, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            if (hit.collider.CompareTag("River"))
            {
                OnDeadBecauseFallInRiver();
            }
        }
    }

    private void ManageIdleTime()
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

    private void OnDeadBecauseFallInRiver()
    {
        if (timeSinceLastDeath <= timeBeforeCheckAgainIsDeath) return;

        print("DeadControllerOfPlayer: Le joueur meurt car il est tombé dans la rivière");
        lifeController.RemoveOneLife();
        timeSinceLastDeath = 0f;
        // EditorApplication.isPlaying = false;
    }

    private void OnDeadBecauseTooIdle()
    {
        if (timeSinceLastDeath < timeBeforeCheckAgainIsDeath) return;

        print("DeadControllerOfPlayer: Le joueur meurt car il est resté trop longtemps inactif");
        lifeController.RemoveOneLife();
        timeSinceLastDeath = 0f;
        totalTimeIdleSinceLastMoveOnZ = 0;
        // EditorApplication.isPlaying = false;
    }

    public void OnDeadBecauseOutsideOfFov()
    {
        if (timeSinceLastDeath < timeBeforeCheckAgainIsDeath) return;

        print("DeadControllerOfPlayer: Le joueur meurt car il n'est plus dans la FOV");
        lifeController.RemoveOneLife();
        timeSinceLastDeath = 0f;
        // EditorApplication.isPlaying = false;
    }

    public void OnDeadBecauseVehicleCollision()
    {
        print("DeadControllerOfPlayer: Le joueur meurt car il se fait percuté par un véhicule");
        lifeController.RemoveOneLife();
        // EditorApplication.isPlaying = false;
    }
}