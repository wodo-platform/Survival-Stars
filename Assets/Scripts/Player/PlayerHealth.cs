using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    [SerializeField] private PlayerAnimation _animation;
    [SerializeField] private UIController _uiController;
    public bool IsDead { get; private set; }
    private int _currentHealth = 0;

    private void Start()
    {
        _currentHealth = health;
    }

    private void TakeDamage()
    {
        if(IsDead) return;
        _currentHealth -= 1;

        if (_currentHealth <= 0)
        {
            IsDead = true;
            SetDead();
        }
        
        _uiController.OnHealthChange(_currentHealth);
        Debug.Log("Damaged, current health: " + _currentHealth);
    }

    private void SetDead()
    {
        _animation.SetDeadState(isDead: true);
        GameManager.instance.EndGame();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
            TakeDamage();
        if(other.CompareTag("Health"))
        {
            AddHealth();
            PoolManager.Instance.ReturnToPool(ObjectType.Health ,other.gameObject);
        }
            
    }

    private void AddHealth()
    {
        _currentHealth++;

        if (_currentHealth > health)
        {
            _currentHealth = health;
        }
        
        _uiController.OnHealthChange(_currentHealth);
        Debug.Log("Added health: " + _currentHealth);
    }
}
