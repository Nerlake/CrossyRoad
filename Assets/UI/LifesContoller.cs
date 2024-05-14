using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifesContoller : MonoBehaviour
{
    private List<Image> lifes = new List<Image>();
    [SerializeField] private GameObject lifesUI;
    //private Vector3 defaultHearthPosition;

    private void Start()
    {
        lifes.AddRange(transform.GetComponentsInChildren<Image>());
        //defaultHearthPosition = lifes[0].transform.position;
        //Debug.Log(defaultHearthPosition.x);
    }

    public bool RemoveOneLife()
    {
        if (lifes.Count <= 0) return false;

        Destroy(lifes[lifes.Count - 1]);
        lifes.RemoveAt(lifes.Count - 1);

        return true;
    }

    public bool AddOneLife()
    {
        if (lifes.Count >= 3)
        {
            Debug.Log("You can't have more than 3 lifes");
            return false;
        }

        Vector3 lastHeartPosition = LastHeartPosition();
        Vector3 newPosition = new Vector3(lastHeartPosition.x - 18, lastHeartPosition.y, lastHeartPosition.z);

        GameObject newLife = Instantiate(lifesUI, newPosition, transform.rotation);
        newLife.transform.SetParent(transform);

        Debug.Log("Add one life");
        return true;
    }

    private Vector3 LastHeartPosition()
    {
        if (lifes.Count <= 0) return new Vector3(0,0,0);

        return lifes[lifes.Count - 1].transform.position;
    }
}