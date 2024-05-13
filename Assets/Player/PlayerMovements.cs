using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private bool isAnimationUpInProgress = false;
    private bool isAnimationDownInProgress = false;

    private float speed = 40f;
    private float heightUp = 0.5f;
    private float interpolation;

    private Vector3 startPositionAnimation;
    private Vector3 endPositionAnimation;

    private GameObject currentSeatOnLog;

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);

        if (isAnimationUpInProgress)
        {
            MoveWithAnimationUp();
            return;
        }

        if (isAnimationDownInProgress)
        {
            MoveWithAnimationDown();
            return;
        }

        KeyboardController();
    }

    private bool checkTree()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1f))
        {
            if (hit.collider.CompareTag("Tree"))
            {
                return true;
            }
        }

        return false;
    }

    private void KeyboardController()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            MoveForward();
        }
    }

    private void MoveForward()
    {
        if (checkTree())
        {
            return;
        }

        if (currentSeatOnLog)
        {
            currentSeatOnLog.GetComponent<SeatController>().playerOnMe = null;
            currentSeatOnLog = null;
        }

        if (checkIfNextPositionIsLog())
        {
            return;
        }

        if (!isAnimationUpInProgress && !isAnimationDownInProgress)
        {
            startPositionAnimation = transform.position;
            endPositionAnimation = startPositionAnimation + transform.forward * 0.5f + Vector3.up * heightUp;
            isAnimationUpInProgress = true;
        }
    }

    private bool checkIfNextPositionIsLog()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.CompareTag("SeatOnLog"))
            {
                currentSeatOnLog = hit.collider.gameObject;
                currentSeatOnLog.GetComponent<SeatController>().playerOnMe = gameObject;

                return true;
            }
        }

        return false;
    }

    private void MoveWithAnimationUp()
    {
        if (interpolation >= 1 && isAnimationUpInProgress)
        {
            isAnimationUpInProgress = false;
            isAnimationDownInProgress = true;
            startPositionAnimation = transform.position;
            endPositionAnimation += transform.forward * 0.5f + Vector3.down * heightUp;
            interpolation = 0;
            return;
        }

        interpolation += speed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPositionAnimation, endPositionAnimation, interpolation);
    }

    private void MoveWithAnimationDown()
    {
        if (interpolation >= 1 && isAnimationDownInProgress)
        {
            isAnimationUpInProgress = false;
            isAnimationDownInProgress = false;
            interpolation = 0;
            roundPosition();
            return;
        }

        interpolation += speed * Time.deltaTime;
        transform.position = Vector3.Lerp(startPositionAnimation, endPositionAnimation, interpolation);
    }

    private void roundPosition()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            Mathf.Round(transform.position.z)
        );
    }
}