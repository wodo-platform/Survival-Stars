using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerAnimation animation;
    [SerializeField] private PlayerHealth playerHealth;
    private Vector2 movement;

    private void Update()
    {
        //Getting inputs 
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        animation.OnMove((int) movement.magnitude);
    }

    private void FixedUpdate()
    {
        if(playerHealth.IsDead)
            return;
        rigidBody.MovePosition(rigidBody.position + movement * moveSpeed * Time.fixedDeltaTime);
        FlipRotation();
    }

    private void FlipRotation()
    {
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movement.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        //Alternative solution
        /*if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }*/
    }
}
