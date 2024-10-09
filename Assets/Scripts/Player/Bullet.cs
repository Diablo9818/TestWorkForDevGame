using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 2f;

    private Rigidbody2D _rigidbody2D;

    private Vector2 _aimDirection;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _aimDirection);
        _rigidbody2D.velocity = _aimDirection * _speed;
        Destroy(gameObject, _lifeTime);
    }

    public void Init(Vector2 aimDirection)
    {
        _aimDirection = aimDirection;
    }
}
