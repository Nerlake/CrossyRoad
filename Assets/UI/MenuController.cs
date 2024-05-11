using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    private bool isPause = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPause = !isPause;

        if (isPause)
        {
            Time.timeScale = 0;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}