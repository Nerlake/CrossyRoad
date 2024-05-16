using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LifesContoller : MonoBehaviour
{
    private int maxLifes = 3;
    [SerializeField] private GameObject lifesUI;
    [SerializeField] private TMP_Text nbLifesText;
    [SerializeField] public int nbLifes = 3;

    private void Start()
    {
        nbLifesText.SetText(nbLifes.ToString());
    }

    public bool RemoveOneLife()
    {
        if (nbLifes <= 0)
        {
            Debug.Log("You can't have less than 0 lifes");
            return false;
        }

        nbLifes--;
        nbLifesText.SetText(nbLifes.ToString());
        Debug.Log("Remove one life");
        return true;
    }

    public bool AddOneLife()
    {
        if (nbLifes >= maxLifes)
        {
            Debug.Log("You can't have more than " + maxLifes + " lifes");
            return false;
        }

        nbLifes++;
        nbLifesText.SetText(nbLifes.ToString());
        Debug.Log("Add one life");
        return true;
    }
}