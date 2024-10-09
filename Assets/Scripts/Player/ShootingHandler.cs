using System.Collections;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [SerializeField] private Bullet _bulletprefab;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _fireRate = 0.1f;

    private Vector2 _aimDirection;

    private void Start()
    {
        StartCoroutine(ShootingCorutine());
    }

    public void SetAimDirection(Vector2 direction)
    {
        _aimDirection = direction;
    }

    private IEnumerator ShootingCorutine()
    {
        while (Time.timeScale != 0)
        {
            yield return new WaitForSeconds(_fireRate);
            Shoot();
        }
    }

    private void Shoot()
    {
        Bullet bullet = Instantiate(_bulletprefab, _spawnPosition.position, Quaternion.identity);
        bullet.Init(_aimDirection);
    }
}
