using UnityEngine;

public class MenuController : MonoBehaviour
{
    private bool isPause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}