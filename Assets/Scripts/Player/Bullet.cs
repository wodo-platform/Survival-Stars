using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    private float _speed;

    public void Init(Vector2 dir, float speed)
    {
        _direction = dir;
        _speed = speed;
    }

    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            PoolManager.Instance.ReturnToPool(ObjectType.Bullet, gameObject);
        }
    }
}
