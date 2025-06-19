using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void OnMove(int speed)
    {
        animator.SetInteger("Speed", speed);
    }
}
