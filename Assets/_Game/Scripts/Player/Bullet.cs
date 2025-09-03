using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D bulletVelocity;

    private void Awake()
    {
        bulletVelocity = GetComponent<Rigidbody2D>();
    }

    public void BulletLogic(float direction)
    {
        if (direction > 0)
            bulletVelocity.linearVelocityX = speed;
        else if (direction < 0)
            bulletVelocity.linearVelocityX = -speed;
    }
}
