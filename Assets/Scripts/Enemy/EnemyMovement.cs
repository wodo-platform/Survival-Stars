using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;
    [SerializeField] EnemyHealth health;
    
    private Transform _target;
    private Vector2 _direction;

    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(health.IsDead)
            return;
        if(_target == null)
            return;
        
        _direction = (_target.position - transform.position).normalized;
        transform.position += (Vector3) _direction * moveSpeed * Time.deltaTime;
        
        FlipRotation();
    }
    
    private void FlipRotation()
    {
        if (_direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(_direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
