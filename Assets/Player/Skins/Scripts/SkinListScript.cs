using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinList", menuName = "ScriptableObjects/SkinList", order = 1)]
public class SkinList : ScriptableObject
{
    public List<SkinObject> skins;
}
