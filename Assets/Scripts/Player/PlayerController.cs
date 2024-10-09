using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ShootingHandler _shootingHandler;

    private void Update()
    {
        HandleAiming();
    }

    private void HandleAiming()
    {
        Vector3 worldPosition;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            worldPosition = Camera.main.ScreenToWorldPoint(touch.position);
        }
        else
        {
            worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        worldPosition.z = 0;
        Vector3 aimDirection = (worldPosition - transform.position).normalized;


        transform.rotation = Quaternion.LookRotation(Vector3.forward, aimDirection);

        _shootingHandler.SetAimDirection(aimDirection.normalized);
    }
}
