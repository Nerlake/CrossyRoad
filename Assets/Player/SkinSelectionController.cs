using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinSelectionController : MonoBehaviour
{
    [SerializeField] public SkinList skinList;
    [SerializeField] private GameObject player;
    private int selectedSkin = 0;

    public void Start()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        player.GetComponent<MeshRenderer>().material = skinList.skins[selectedSkin];
    }

    public void NextSkin()
    {
        selectedSkin++;
        if (selectedSkin >= skinList.skins.Count)
        {
            selectedSkin = 0;
        }
        player.GetComponent<MeshRenderer>().material = skinList.skins[selectedSkin];
    }

    public void PreviousSkin()
    {
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin = skinList.skins.Count - 1;
        }
        player.GetComponent<MeshRenderer>().material = skinList.skins[selectedSkin];
    }


    public void ExitToHome()
    {
        PlayerPrefs.SetInt("selectedSkin", selectedSkin);

        SceneManager.LoadScene("Home");
    }
}
