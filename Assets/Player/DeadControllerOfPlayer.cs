using UnityEditor;
using UnityEngine;

public class DeadControllerOfPlayer : MonoBehaviour
{
    public void OnDeadBecauseOutsideOfFov()
    {
        print("DeadControllerOfPlayer: Le joueur meurt car il n'est plus dans la FOV");
        EditorApplication.isPlaying = false;
    }
}