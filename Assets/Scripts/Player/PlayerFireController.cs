using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate = .5f;
    
    private float _fireCooldown;

    void Update()
    {
        _fireCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && _fireCooldown <= 0)
        {
            ShootProjectile();
            _fireCooldown = fireRate;
        }
    }

    private void ShootProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        
        Vector2 direction = (mousePosition - transform.position).normalized;
        
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Init(direction, bulletSpeed);
    }
}
