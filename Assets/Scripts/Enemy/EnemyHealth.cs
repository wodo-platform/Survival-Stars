using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private int _currentHealth;
    public bool IsDead => _currentHealth <= 0;

    private void OnEnable()
    {
        _currentHealth = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
            GetDamage();
        if (other.gameObject.CompareTag("Player"))
            Explode();
    }

    private void Explode()
    {
        Destroy(gameObject);
    }

    private void GetDamage()
    {
        _currentHealth -= 1;
        if(_currentHealth <= 0)
            Explode();
    }
}
