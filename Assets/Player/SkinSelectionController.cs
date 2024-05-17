using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinSelectionController : MonoBehaviour
{
    [SerializeField] public SkinList skinList;
    [SerializeField] private GameObject player;
    [SerializeField] private TMP_Text skinName;
    [SerializeField] private TMP_Text skinPrice;
    [SerializeField] private Button selectButton;
    [SerializeField] private Image cadena;
    private int initialSkin = 0;
    private int selectedSkin = 0;

    public void Start()
    {

        initialSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        selectedSkin = initialSkin;
        DisplaySkin();
    }

    public void NextSkin()
    {
        selectedSkin++;
        if (selectedSkin >= skinList.skins.Count)
        {
            selectedSkin = 0;
        }
        DisplaySkin();

    }

    public void PreviousSkin()
    {
        selectedSkin--;
        if (selectedSkin < 0)
        {
            selectedSkin = skinList.skins.Count - 1;
        }
        DisplaySkin();
    }


    public void ExitToHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void SelectSkin()
    {
        if (DoesThePlayerHaveTheSkin())
        {
            PlayerPrefs.SetInt("selectedSkin", selectedSkin);
            initialSkin = selectedSkin;
            DisplaySkin();
        }
    }

    private bool DoesThePlayerHaveTheSkin()
    {
        int score = PlayerPrefs.GetInt("cumulatedScore");
        return score >= skinList.skins[selectedSkin].scoreMin;
    }


    private void DisplaySkin()
    {
        player.GetComponent<MeshRenderer>().material = skinList.skins[selectedSkin].Skin;

        string name = skinList.skins[selectedSkin].skinName;
        int score = PlayerPrefs.GetInt("cumulatedScore");
        skinName?.SetText(name.ToString());
        if (DoesThePlayerHaveTheSkin())
        {
            skinPrice?.SetText("");
        }
        else
        {
            int scoreToUnlock = skinList.skins[selectedSkin].scoreMin - score;
            skinPrice?.SetText("Unlocked in : " + scoreToUnlock.ToString() + " pts");
        }

        if(selectButton != null)
        {
            if(selectedSkin == initialSkin)
            {
                SetButtonSelected();
                cadena.enabled = false;
            }
            else
            {
                if(DoesThePlayerHaveTheSkin())
                {
                    SetButtonUnselected();
                    cadena.enabled = false;
                }
                else
                {
                    SetButtonLocked();
                    cadena.enabled = true;
                }
            }
        }


    }

    private void SetButtonSelected()
    {
        selectButton.interactable = false;
        selectButton.GetComponentInChildren<TMP_Text>().SetText("Selected");
    }

    private void SetButtonUnselected()
    {
        selectButton.interactable = true;
        selectButton.GetComponentInChildren<TMP_Text>().SetText("Select");
    }

    private void SetButtonLocked()
    {
        selectButton.interactable = false;
        selectButton.GetComponentInChildren<TMP_Text>().SetText("Locked");
    }
    
}
