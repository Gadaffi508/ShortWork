using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20.0f;
    public Rigidbody2D rb;
    public int damage = 40;

    private void Awake()
    {
        rb.velocity=transform.right*speed;
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy= hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
