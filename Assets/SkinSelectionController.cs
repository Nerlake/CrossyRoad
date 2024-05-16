using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectionController : MonoBehaviour
{
    public Material[] skins;
    public GameObject player;
    public int selectedSkin = 0;

    public void Start()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        player.GetComponent<MeshRenderer>().material = skins[selectedSkin];
    }

    public void NextSkin()
    {
        selectedSkin++;
        if (selectedSkin >= skins.Length)
        {
            selectedSkin = 0;
        }
        player.GetComponent<MeshRenderer>().material = skins[selectedSkin];
    }

    public void PreviousSkin()
    {
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin = skins.Length - 1;
        }
        player.GetComponent<MeshRenderer>().material = skins[selectedSkin];
    }


    public void ExitToHome()
    {
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);

        SceneManager.LoadScene("Home");
    }
}
