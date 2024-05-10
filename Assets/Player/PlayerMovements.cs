using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private bool isAnimationUpInProgress = false;
    private bool isAnimationDownInProgress = false;

    private float speed = 20f;
    private float heightUp = 1f;
    private float interpolation;

    private Vector3 startPositionAnimation;
    private Vector3 endPositionAnimation;

    private void Update()
    {
        if (isAnimationUpInProgress)
        {
            MoveWithAnimationUp();
            return;
        }

        KeyboardController();
    }

    private void KeyboardController()
    {
        if (isAnimationDownInProgress)
        {
            MoveWithAnimationDown();
            return;
        }

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
        if (!isAnimationUpInProgress && !isAnimationDownInProgress)
        {
            startPositionAnimation = transform.position;
            endPositionAnimation = startPositionAnimation + transform.forward * 0.5f + Vector3.up * heightUp;
            isAnimationUpInProgress = true;
        }
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