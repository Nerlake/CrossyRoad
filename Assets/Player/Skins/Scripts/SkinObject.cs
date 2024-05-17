using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinObject", menuName = "ScriptableObjects/SkinObject", order = 2)]
public class SkinObject : ScriptableObject
{

    public Material Skin;
    public string skinName;
    public int scoreMin;

}
