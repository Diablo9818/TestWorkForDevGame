using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private  float _speed;
    [SerializeField] private int _points;

    private Transform _target;

    public void Init(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        Vector2 direction = (_target.position - transform.position).normalized;

        if (_target.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            GameManager.Instance.AddScore(_points);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            GameManager.Instance.GameOver();
        }

        if(other.TryGetComponent(out Bullet bullet))
        {
            TakeDamage(1);
            Destroy(bullet.gameObject);
        }
    }
}
