using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesContoller : MonoBehaviour
{
    private List<Image> lifes = new List<Image>();

    private void Start()
    {
        lifes.AddRange(transform.GetComponentsInChildren<Image>());
    }

    public bool RemoveOneLife()
    {
        if (lifes.Count <= 0) return false;

        Destroy(lifes[lifes.Count - 1]);
        lifes.RemoveAt(lifes.Count - 1);

        return true;
    }
}