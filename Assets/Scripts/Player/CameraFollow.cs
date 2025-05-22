using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        this.transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
