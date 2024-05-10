using UnityEngine;

public class DetectIfPlayerOusideFov : MonoBehaviour
{
    private Renderer player;
    private Camera camera;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Renderer>();
        camera = Camera.main;
    }
    private void Update()
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        if (!GeometryUtility.TestPlanesAABB(planes, player.bounds))
        {
            print("Le joueur n'est plus dans le champ de vision de la caméra");
        }
    }
}
