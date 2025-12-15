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
        SoundManager.instance.ChangeMusic(SoundType.GameMusic);
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
        else
        {
            SoundManager.instance.PlaySfx(SoundType.DamageSFX);
        }
        
        _uiController.OnHealthChange(_currentHealth);
        Debug.Log("Damaged, current health: " + _currentHealth);
    }

    private void SetDead()
    {
        _animation.SetDeadState(isDead: true);
        SoundManager.instance.ChangeMusic(SoundType.GameOverMusic);
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
        SoundManager.instance.PlaySfx(SoundType.HealthCollectSFX);
        _uiController.OnHealthChange(_currentHealth);
        Debug.Log("Added health: " + _currentHealth);
    }
}
