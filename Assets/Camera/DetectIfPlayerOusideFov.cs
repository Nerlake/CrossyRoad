using UnityEngine;

public class DetectIfPlayerOusideFov : MonoBehaviour
{
    private DeadControllerOfPlayer deadControllerOfPlayer;
    private Renderer playerRenderer;
    private Camera _camera;

    private void Start()
    {
        deadControllerOfPlayer = GameObject.Find("Player").GetComponent<DeadControllerOfPlayer>();
        playerRenderer = GameObject.Find("Player").GetComponent<Renderer>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);
        if (!GeometryUtility.TestPlanesAABB(planes, playerRenderer.bounds))
        {
            print("Camera: Le joueur n'est plus dans le champ de vision de la caméra");
            deadControllerOfPlayer.OnDeadBecauseOutsideOfFov();
        }
    }
}